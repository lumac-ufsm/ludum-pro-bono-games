using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerPacmaze : MonoBehaviour {
	[SerializeField] private Canvas canvas;
	[SerializeField] private GameOverMenu gameOverMenu;
	[SerializeField] private Text scoreText;
	private ScoreManagerPacmaze scoreManager;
	private static int _score = 0;
	public static int score {
		get { return _score; }
	}

	public static GameManagerPacmaze Get() {
		return GameObject.Find("GameManagerPacmaze").GetComponent<GameManagerPacmaze>();
	}

	private void Start() {
		scoreManager = GetComponent<ScoreManagerPacmaze>();
	}

	private void GameOverMenu() {
		scoreText.text = $"Pontuação: {_score}";
		gameOverMenu.GameOver();
		scoreManager.RegisterScore();
	}

	public void OnFinishLevel() {
		_score += scoreManager.GetScore();
		print(_score);
		string name = SceneManager.GetActiveScene().name;
		int level = int.Parse(name.Replace("_PacmazeLevel", ""));
		string nextSceneName = $"{level + 1}_PacmazeLevel";
		if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
			SceneManager.LoadScene(nextSceneName);
		} else {
			GameOverPacmaze.GameOver(_score);
		}
	}
}
