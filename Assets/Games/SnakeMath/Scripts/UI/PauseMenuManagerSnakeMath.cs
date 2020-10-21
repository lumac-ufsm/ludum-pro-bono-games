using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManagerSnakeMath : MonoBehaviour {
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button resumeButton;
    [SerializeField] Button menuButton;
    private float pauseAnimationLength;

    private void Start() {
        pauseMenu.SetActive(false);
        Animator animator = pauseMenu.GetComponent<Animator>();
        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0];
        pauseAnimationLength = animationClip.length;

        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(OpenMenu);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            if (pauseMenu.active) Resume();
            else Pause();
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
        SceneRouter.OpenGameMenu("SnakeMath");
    }
}
