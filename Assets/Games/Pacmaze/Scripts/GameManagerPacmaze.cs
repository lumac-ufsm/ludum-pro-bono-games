using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPacmaze : MonoBehaviour {
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameOverMenu gameOverMenu;
    
    private void GameOver() {
        gameOverMenu.GameOver();
    }

    public void OnFinishLevel() {
        string name = SceneManager.GetActiveScene().name;
        int level = int.Parse(name.Replace("_PacmazeLevel", ""));
        if (level == 7) {
            GameOver();
        } else {
            SceneManager.LoadScene($"{level + 1}_PacmazeLevel");
        }
    }
}
