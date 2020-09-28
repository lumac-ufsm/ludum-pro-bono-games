using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeDeathSnakeMath : MonoBehaviour {
    private SnakeSnakeMath snake;

    private void Start() {
        snake = GetComponent<SnakeSnakeMath>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && !snake.isStart) {
            gameOver();
        }
    }

    private void gameOver() {
        PointsSnakeMath.points = snake.points;
        SceneManager.LoadScene("Games/SnakeMath/Scenes/GameOver");
    }
}
