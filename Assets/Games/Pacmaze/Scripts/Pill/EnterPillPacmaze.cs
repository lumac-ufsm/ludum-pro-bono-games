using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPillPacmaze : MonoBehaviour {
    private GameManagerPacmaze gameManagerPacmaze;

    private void Start() {
        gameManagerPacmaze = GameObject.Find("GameManagerPacmaze").GetComponent<GameManagerPacmaze>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameManagerPacmaze.OnFinishLevel();
        }
    }
}
