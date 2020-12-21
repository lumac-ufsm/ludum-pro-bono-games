using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    private float pauseAnimationLength;
    [SerializeField] private string gameName;

    private void Start() {
        pauseMenu.SetActive(false);
        Animator animator = pauseMenu.GetComponent<Animator>();
        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0];
        pauseAnimationLength = animationClip.length;

        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(OpenMenu);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            if (pauseMenu.activeSelf) OpenMenu();
            else Pause();
        }
        if (Input.GetKeyDown(Keys.start)) {
            if (pauseMenu.activeSelf) Resume();
        }
    }

    private void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void OpenMenu() {
        Time.timeScale = 1;
        SceneRouter.OpenGameMenu(GameManager.currentGame);
    }
}
