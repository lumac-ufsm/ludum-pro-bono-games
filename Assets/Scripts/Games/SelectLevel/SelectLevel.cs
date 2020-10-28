using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private GameObject panelButtons;
    [SerializeField] private GameObject openLevelButtonPrefab;
    [SerializeField] private int numberOfLevels = 1;

    private void Start() {
        for (int n = 1; n <= numberOfLevels; n++) {
            CreateOpenLevelButton(n);
        }
    }

    private void CreateOpenLevelButton(int levelNumber) {
        GameObject button = Instantiate(openLevelButtonPrefab);
        button.AddComponent<OpenLevelButton>();
        OpenLevelButton openLevelButton = button.GetComponent<OpenLevelButton>();
        openLevelButton.level = new LevelBomberdev(levelNumber, true);
        button.transform.SetParent(panelButtons.transform, false);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            SceneRouter.OpenMain();
        }
    }
}
