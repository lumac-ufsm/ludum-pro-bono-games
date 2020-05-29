using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private List<Direction> directions = new List<Direction>();
    private Vector2 oldPosition;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float forceIntensity = 1;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
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
        directions.Add(direction);
    }

    private Vector2 CalcPosition(Vector2 currentPosition, Direction direction) {
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

        Vector2 position = currentPosition + translate;
        return position;
    }

    private void Run() {
        if (directions.Count > 0) {
            Direction direction = directions[0];
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = CalcPosition(oldPosition, direction);

            bool endTranslate = currentPosition == nextPosition;

            if (direction == Direction.RIGHT) endTranslate = currentPosition.x >= nextPosition.x;
            else if (direction == Direction.LEFT) endTranslate = currentPosition.x <= nextPosition.x;
            else if (direction == Direction.UP) endTranslate = currentPosition.y >= nextPosition.y;
            else if (direction == Direction.DOWN) endTranslate = currentPosition.y <= nextPosition.y;

            if (endTranslate) {
                Stop();
            } else {
                if (direction == Direction.DOWN || direction == Direction.UP) {
                    rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                } else if (direction == Direction.LEFT || direction == Direction.RIGHT) {
                    rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                }
                Vector2 force = nextPosition - currentPosition;
                force *= forceIntensity;
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
        oldPosition = position;
        if (directions.Count > 0) directions.RemoveAt(0);
    }
}
