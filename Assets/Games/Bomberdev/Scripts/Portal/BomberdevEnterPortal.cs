using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberdevEnterPortal : MonoBehaviour {
    private GameManagerBomberdev gameManager;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBomberdev>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            gameManager.NextLevel();
        }
    }
}
