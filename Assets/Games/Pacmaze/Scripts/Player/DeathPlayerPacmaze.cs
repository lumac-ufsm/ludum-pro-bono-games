using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerPacmaze : MonoBehaviour {
    private Vector2 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            gameObject.transform.position = initialPosition;
        }
    }
}
