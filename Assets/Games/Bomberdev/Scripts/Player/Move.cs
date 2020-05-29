using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private List<Translation> translations = new List<Translation>();
    private Vector2 oldPosition;
    private Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;

        Translate(Direction.LEFT);
        Translate(Direction.LEFT);
        Translate(Direction.LEFT);
        Translate(Direction.UP);
    }

    private void Update() {
        Run();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Stop();
        }
    }

    public void Translate(Direction direction) {
        Vector2 translate = Vector2.zero;
        switch(direction) {
            case Direction.UP:
                translate = new Vector2(0, 1);
                break;
            case Direction.DOWN:
                translate = new Vector2(0, -1);
                break;
            case Direction.LEFT:
                translate = new Vector2(-1, 0);
                break;
            case Direction.RIGHT:
                translate = new Vector2(1, 0);
                break;
        }

        Vector2 position;
        if (translations.Count > 0) {
            position = translations[translations.Count - 1].position + translate;
        } else {
            position = ((Vector2) transform.position) + translate;
        }
        position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        translations.Add(new Translation(direction, position));
    }

    private void Run() {
        if (translations.Count > 0) {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = translations[0].position;
            Direction direction = translations[0].direction;

            bool endTranslate = currentPosition == nextPosition;

            if (direction == Direction.RIGHT) endTranslate = currentPosition.x >= nextPosition.x;
            else if (direction == Direction.LEFT) endTranslate = currentPosition.x <= nextPosition.x;
            else if (direction == Direction.UP) endTranslate = currentPosition.y >= nextPosition.y;
            else if (direction == Direction.DOWN) endTranslate = currentPosition.y <= nextPosition.y;

            if (endTranslate) {
                oldPosition = nextPosition;
                Stop();
            } else {
                if (direction == Direction.DOWN || direction == Direction.UP) {
                    rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                } else if (direction == Direction.LEFT || direction == Direction.RIGHT) {
                    rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                }
                var force = nextPosition - currentPosition;
                rigidbody2D.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }

    private void Stop() {
        rigidbody2D.Sleep();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        transform.position = position;
        if (translations.Count > 0) translations.RemoveAt(0);
    }
}
