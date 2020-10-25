﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] private Button startGameButton;
    [SerializeField, Scene] private string scene;

    private void Start() {
        startGameButton.onClick.AddListener(StartGame);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            StartGame();
        }
        if (Input.GetKeyDown(Keys.back)) {
            SceneRouter.OpenMain();
            GameManager.currentGame = null;
        }
    }

    private void StartGame() => SceneRouter.OpenScene(scene);
}
