using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private GameObject panelButtons;
    [SerializeField] private GameObject openLevelButtonPrefab;
    [SerializeField] private int _numberOfLevels = 1;
    [SerializeField] private GameName gameName;
    public static int numberOfLevelsCurrentGame;

    private void Start() {
        numberOfLevelsCurrentGame = _numberOfLevels;
        for (int n = 1; n <= _numberOfLevels; n++) {
            CreateOpenLevelButton(n);
        }
    }

    private void CreateOpenLevelButton(int levelNumber) {
        GameObject button = Instantiate(openLevelButtonPrefab);
        OpenLevelButton openLevelButton = button.GetComponent<OpenLevelButton>();
        openLevelButton.level = CreateLevel(levelNumber);
        button.transform.SetParent(panelButtons.transform, false);
    }

    protected Level CreateLevel(int levelNumber) {
        return new Level(gameName.ToString(), levelNumber, true);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            SceneRouter.OpenMain();
        }
    }
}
