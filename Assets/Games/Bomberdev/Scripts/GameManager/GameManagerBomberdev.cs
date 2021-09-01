using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBomberdev : MonoBehaviour {
	[SerializeField] private PanelFlowchartBomberdev panelFlowchart;
	[SerializeField] private GameObject panelGameOver;
	[SerializeField] private Text scoreText;
	private RunCommandsBomberdev runCommandsBomberdev;
	private ScoreManagerBomberdev scoreManager;
	private static int _score = 0;
	public static int score {
		get { return _score; }
	}

	public static GameManagerBomberdev Get() {
		return GameObject.Find("GameManagerBomberdev").GetComponent<GameManagerBomberdev>();
	}

	private void Start() {
		Time.timeScale = 1;
		scoreManager = GetComponent<ScoreManagerBomberdev>();
	}

	private void Update() {
		runCommandsBomberdev = GetComponent<RunCommandsBomberdev>();
		if (Time.timeScale > 0) Inputs();
	}

	private void Inputs() {
		if (Input.GetKeyDown(Keys.up)) panelFlowchart.MoveOrSelect(Direction.UP);
		if (Input.GetKeyDown(Keys.down)) panelFlowchart.MoveOrSelect(Direction.DOWN);
		if (Input.GetKeyDown(Keys.left)) panelFlowchart.MoveOrSelect(Direction.LEFT);
		if (Input.GetKeyDown(Keys.right)) panelFlowchart.MoveOrSelect(Direction.RIGHT);
		if (Input.GetKeyDown(Keys.action1)) panelFlowchart.ToggleHold();
		if (Input.GetKeyDown(Keys.action4)) runCommandsBomberdev.StartCommands();
	}

	public void OnFinishLevel() {
		_score += scoreManager.GetScore();
		print(_score);
		string name = SceneManager.GetActiveScene().name;
		int level = int.Parse(name.Replace("_BomberdevLevel", ""));
		string nextSceneName = $"{level + 1}_BomberdevLevel";
		if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
			SceneManager.LoadScene(nextSceneName);
		} else {
			GameOverBomberdev.GameOver(_score);
		}
	}

	public void RestartLevel() {
		string name = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(name);
	}

	public void GameOver(string deathCause) {
		scoreText.text = $"Pontuação: {_score}";
		Time.timeScale = 0;
		panelGameOver.SetActive(true);
		print($"Game Over\nCausa da morte: {deathCause}");
		GameManager.GetScoreRegisterManager().OpenScoreRegisterPanel(_score);
	}
}
