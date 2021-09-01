using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBomberdev : MonoBehaviour {
	[SerializeField] private Text pointsText;
	private static int score = 0;

	private void Start() {
		int score = GameOverBomberdev.score;
		pointsText.text = $"Pontuação: {score}";
		GameManager.GetScoreRegisterManager().OpenScoreRegisterPanel(score);
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.start)) {
			SceneManager.LoadScene("Games/Bomberdev/Scenes/Main");
		}
	}

	public static void GameOver(int score) {
		GameOverBomberdev.score = score;
		SceneManager.LoadScene("Games/Bomberdev/Scenes/GameOver");
	}
}
