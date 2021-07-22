using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSnakeMath : MonoBehaviour {
	[SerializeField] private Text pointsText;
	private static int points = 0;

	private void Start() {
		int score = GameOverSnakeMath.points;
		pointsText.text = $"Pontuação: {score}";
		GameManager.GetScoreRegisterManager().OpenScoreRegisterPanel(score);
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.start)) {
			SceneManager.LoadScene("Games/SnakeMath/Scenes/Main");
		}
	}

	public static void GameOver(int points) {
		GameOverSnakeMath.points = points;
		SceneManager.LoadScene("Games/SnakeMath/Scenes/GameOver");
	}
}