using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPacmaze : MonoBehaviour {
	[SerializeField] private Canvas canvas;
	[SerializeField] private GameOverMenu gameOverMenu;
	private ScoreManagerPacmaze scoreManagerPacmaze;
	private static int _score = 0;
	public static int score {
		get { return _score; }
	}
	private void GameOver() {
		scoreText.text = $"Pontuação: {_score}";
		gameOverMenu.GameOver();
	}

	public void OnFinishLevel() {
		int _score =+ scoreManagerPacmaze.GetScore();
		print(_score);
		string name = SceneManager.GetActiveScene().name;
		int level = int.Parse(name.Replace("_PacmazeLevel", ""));
		string nextSceneName = $"{level + 1}_PacmazeLevel";
		if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
			SceneManager.LoadScene(nextSceneName);
		} else {
			GameOver();
		}
	}
}
