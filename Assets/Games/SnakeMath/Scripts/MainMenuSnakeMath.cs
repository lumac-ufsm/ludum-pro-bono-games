using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSnakeMath : MonoBehaviour {
    [SerializeField] Button startGameButton;

    private void Start() {
        startGameButton.onClick.AddListener(StartGame);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            StartGame();
        }
    }

    private void StartGame() => SceneRouter.OpenGame("SnakeMath");
}
