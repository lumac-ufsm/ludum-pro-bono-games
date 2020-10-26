using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPlayerBomberdev : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D playerRigidbody2D;
    
    private void Start() {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (playerRigidbody2D.velocity == Vector2.zero) {
            animator.SetBool("stopped", true);
            animator.enabled = false;
        } else {
            animator.enabled = true;
            animator.SetBool("stopped", false);
            animator.SetFloat("velocityX", playerRigidbody2D.velocity.x);
            animator.SetFloat("velocityY", playerRigidbody2D.velocity.y);
        }
    }
}
