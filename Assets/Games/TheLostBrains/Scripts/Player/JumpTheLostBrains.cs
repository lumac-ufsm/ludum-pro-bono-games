using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTheLostBrains : MonoBehaviour {
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private float forceJump = 1f;
    [SerializeField] private Animator animator;
    private bool allowJump = true;

    void Start() {
    }

    void Update() {
        float jump = Input.GetMouseButtonDown(0) == true ? 1 : Input.GetAxis("Jump");
        Vector2 speed = playerRigidbody2D.GetPointVelocity(new Vector2(0, 0));
        if (jump > 0 && !isJumping && speed.y <= 0.01f) {
            playerRigidbody2D.AddForce(new Vector2(0, forceJump * jump), ForceMode2D.Impulse);
            isJumping = true;
        }

        animator.SetBool("jump", isJumping);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isJumping = false;
    }
}
