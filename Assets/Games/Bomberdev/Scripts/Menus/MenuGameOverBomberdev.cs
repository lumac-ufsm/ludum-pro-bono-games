using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameOverBomberdev : MonoBehaviour {
    [SerializeField] private Button restartLevelButton;
    private void Start() {
        restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) RestartLevel();
    }

    private void RestartLevel() {
        GameManagerBomberdev gameManager = GameManagerBomberdev.Get();
        gameManager.RestartLevel();
    }
}