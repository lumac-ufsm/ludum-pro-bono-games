using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    public static string currentGame;

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

    private static string GetActiveGameName() {
        Scene activeScene = SceneManager.GetActiveScene();
        string path = activeScene.path;
        string gameName = Regex.Replace(path, "Assets\\/Games\\/([a-zA-Z]+)\\/Scenes\\/.+", "$1");
        if (gameName == path) return null;
        return gameName;
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
        else if (sceneName == "GameIntroduction" || sceneName == "Main") {
            Time.timeScale = 1;
            SceneRouter.OpenMain();
        } else {
            string currentGameName = GetActiveGameName();
            SceneRouter.OpenGameMenu(currentGame);
        }
    }
}
