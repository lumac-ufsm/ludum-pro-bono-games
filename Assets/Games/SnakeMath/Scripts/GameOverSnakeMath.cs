using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSnakeMath : MonoBehaviour {
    public Text textPontuacao;

    void Start() {
        textPontuacao.text = "Pontuação: " + SnakeStorage.points;
    }

    void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            SceneManager.LoadScene("Games/SnakeMath/Scenes/Main");
        }
    }
}
