using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheLostBrains : MonoBehaviour {
    public Rigidbody2D playerRigidbody2D;
    public Animator animator;
    public float modVelocity = 1f;
    public bool isStopped;
    public LayerMask layerMaskPlatform;
    public static Vector2 externalSpeed;
    public bool runMode = false;

    void Start() {
        externalSpeed = new Vector2(0, 0);
    }

    void Update() {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        float deltaX = axisX * modVelocity * Time.deltaTime;

        if (runMode) {
            animator.SetBool("stop", false);
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }
        else {
            animator.SetBool("stop", deltaX == 0 ? true : false);
            animator.SetBool("left", deltaX < 0 ? true : false);
            animator.SetBool("right", deltaX > 0 ? true : false);
        }

        transform.Translate(new Vector3(deltaX, 0, 0));
    }
}
