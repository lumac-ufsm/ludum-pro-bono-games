using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePacmaze : MonoBehaviour {
    private Vector2 direction;
    [SerializeField] private Collider2D colliderUp;
    [SerializeField] private Collider2D colliderDown;
    [SerializeField] private Collider2D colliderLeft;
    [SerializeField] private Collider2D colliderRight;
    [SerializeField] private Animator animator;
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    void Start()     {
        direction = Vector2.zero;
    }

    void Update() {
        up = colliderUp.IsTouchingLayers();
        down = colliderDown.IsTouchingLayers();
        left = colliderLeft.IsTouchingLayers();
        right = colliderRight.IsTouchingLayers();

        if (direction.Equals(Vector2.zero)) {
            if (Input.GetKeyDown(Keys.left))
                if (!colliderLeft.IsTouchingLayers()) Move(Vector2.left);

            if (Input.GetKeyDown(Keys.right))
                if (!colliderRight.IsTouchingLayers()) Move(Vector2.right);

            if (Input.GetKeyDown(Keys.up))
                if (!colliderUp.IsTouchingLayers()) Move(Vector2.up);

            if (Input.GetKeyDown(Keys.down))
                if (!colliderDown.IsTouchingLayers()) Move(Vector2.down);
        }
    }

    private void FixedUpdate() {
        transform.Translate(direction);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    private void Move(Vector2 direction) {
        this.direction = direction;
    }

    private void Stop() {
        direction = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (
            direction.y > 0 && colliderUp.IsTouchingLayers() ||
            direction.y < 0 && colliderDown.IsTouchingLayers() ||
            direction.x < 0 && colliderLeft.IsTouchingLayers() ||
            direction.x > 0 && colliderRight.IsTouchingLayers()
        ) Stop();
    }
}
