using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerPacmaze : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            gameObject.transform.position = new Vector2(-20.5f,-12.5f);
        }
    }
}
