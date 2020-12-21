using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {
    [SerializeField] private Button mainButton;
    [SerializeField] private Button menuButton;

    private void Start() {
        gameObject.SetActive(false);
        Animator animator = gameObject.GetComponent<Animator>();
        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0];

        mainButton.onClick.AddListener(OpenMain);
        menuButton.onClick.AddListener(OpenMenu);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            OpenMain();
        }
        if (Input.GetKeyDown(Keys.start)) {
            OpenMenu();
        }
    }

    public void GameOver() {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OpenMenu() {
        Time.timeScale = 1;
        SceneRouter.OpenGameMenu(GameManager.currentGame);
    }

    private void OpenMain() {
        Time.timeScale = 1;
        SceneRouter.OpenMain();
    }
}
