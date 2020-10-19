using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeDeathSnakeMath : MonoBehaviour {
    private SnakeSnakeMath snake;
    private TimeManagerSnakeMath timeManager;

    private void Start() {
        snake = GetComponent<SnakeSnakeMath>();
        timeManager = GameObject.Find("GameManagerSnakeMath").GetComponent<TimeManagerSnakeMath>();
    }

    private void Update() {
        if (timeManager.time == 0) {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && snake.isStarted) {
            GameOver();
        }
    }

    private void GameOver() {
        GameOverSnakeMath.GameOver(snake.bodyList.Count);
    }
}
