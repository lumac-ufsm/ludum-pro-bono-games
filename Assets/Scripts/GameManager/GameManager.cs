using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private static GameManager instance = null;
	public static string currentGame;

	public static GameManager Get() {
		return GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Start() {
		StartRestart();
	}

	private void Restart() {
		StartRestart();
	}

	private void StartRestart() {
		// Cursor.visible = false;
	}

	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Restart();
			Destroy(gameObject);
		}
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.back)) {
			OnBackPress();
		}
	}

	private void OnBackPress() {
		Scene activeScene = SceneManager.GetActiveScene();
		string sceneName = activeScene.name;
		if (activeScene.path == "Assets/Main/Scenes/Main.unity") return;
		else if (sceneName == "Main") {
			Time.timeScale = 1;
			SceneRouter.OpenMain();
		}
	}
}
