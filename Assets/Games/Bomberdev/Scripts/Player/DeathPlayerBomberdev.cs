using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerBomberdev : MonoBehaviour {
    private GameManagerBomberdev gameManagerBomberdev;

    private void Start() {
        gameManagerBomberdev = GameObject.Find("GameManager").GetComponent<GameManagerBomberdev>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Death("Colisão com inimigo");
        } else if (other.CompareTag("Explosion")) {
            Death("Colisão com explosão");
        }
    }

    private void Death(string deathCause) {
        gameManagerBomberdev.GameOver(deathCause);
    }
}
