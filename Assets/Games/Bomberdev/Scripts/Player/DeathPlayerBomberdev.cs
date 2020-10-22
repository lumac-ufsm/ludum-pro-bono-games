using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerBomberdev : MonoBehaviour {
    private GameManagerBomberdev gameManagerBomberdev;

    private void Start() {
        gameManagerBomberdev = GameManagerBomberdev.Get();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Death("Colisão com inimigo");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Explosion")) {
            Death("Colisão com explosão");
        }
    }

    private void Death(string deathCause) {
        Destroy(gameObject);
        gameManagerBomberdev.GameOver(deathCause);
    }
}
