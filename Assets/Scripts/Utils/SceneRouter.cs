using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRouter : MonoBehaviour {
    public static void OpenScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public static void OpenMain() {
        SceneManager.LoadScene("Main/Scenes/Main");
    }

    public static void OpenGameMenu(string gameName) {
        SceneManager.LoadScene($"Games/{gameName}/Scenes/Main"); 
    }

    public static void OpenGame(string gameName) {
        SceneManager.LoadScene($"Games/{gameName}/Scenes/Game"); 
    }

    public static void OpenGameLevel(string gameName, int level) {
        SceneManager.LoadScene($"Games/{gameName}/Scenes/Levels/{level}_{gameName}Level");
    }
}
