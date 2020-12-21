using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class GameManagerPacmaze : MonoBehaviour {
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameOverMenu gameOverMenu;

    public static int CountLevels() {
        var path = Path.Combine(Application.dataPath, "Games", "Pacmaze", "Scenes", "Levels");
        var info = new DirectoryInfo(path);
        FileInfo[] fileInfoArray = info.GetFiles();
        string[] filenames = fileInfoArray.Select(fileInfo => fileInfo.Name).ToArray();
        int countLevels = (int) filenames.Count() / 2;
        return countLevels;
    }

    private void GameOver() {
        gameOverMenu.GameOver();
    }

    public void OnFinishLevel() {
        string name = SceneManager.GetActiveScene().name;
        int level = int.Parse(name.Replace("_PacmazeLevel", ""));
        if (level == CountLevels()) {
            GameOver();
        } else {
            SceneManager.LoadScene($"{level + 1}_PacmazeLevel");
        }
    }
}
