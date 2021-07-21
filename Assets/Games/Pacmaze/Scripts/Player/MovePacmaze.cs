using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePacmaze : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 60;
    private Vector2 direction;
    private Rigidbody2D rigidbodyPacmaze;
    private static int _moveCount = 0;
	public static int moveCount {
		get { return _moveCount; }
	}

    void Start() {
        rigidbodyPacmaze = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
    }

    void Update() {
        if (direction.Equals(Vector2.zero)) {
            if (Input.GetKeyDown(Keys.left)) Move(Vector2.left);
            if (Input.GetKeyDown(Keys.right)) Move(Vector2.right);
            if (Input.GetKeyDown(Keys.up)) Move(Vector2.up);
            if (Input.GetKeyDown(Keys.down)) Move(Vector2.down);
        }

        rigidbodyPacmaze.AddForce(direction * speed, ForceMode2D.Impulse);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        direction = Vector2.zero;

        if (rigidbodyPacmaze.velocity == Vector2.zero) Stop();
    }

    private void Move(Vector2 direction) {
        if (rigidbodyPacmaze.velocity == Vector2.zero) {
            this.direction = direction;
            _moveCount += 1;
        }
    }

    private void Stop() {
        int x = (int) Mathf.Round(transform.position.x);
        int y = (int) Mathf.Round(transform.position.y);
        transform.position = new Vector2(x, y);
        direction = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Stop();
        }
    }
}
