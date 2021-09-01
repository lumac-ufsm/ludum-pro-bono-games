using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPacmaze : MonoBehaviour {
	[SerializeField] private Text pointsText;
	private static int score = 0;

	private void Start() {
		int score = GameOverPacmaze.score;
		pointsText.text = $"Pontuação: {score}";
		GameManager.GetScoreRegisterManager().OpenScoreRegisterPanel(score);
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.start)) {
			SceneManager.LoadScene("Games/Pacmaze/Scenes/Main");
		}
	}

	public static void GameOver(int score) {
		GameOverPacmaze.score = score;
		SceneManager.LoadScene("Games/Pacmaze/Scenes/GameOver");
	}
}
