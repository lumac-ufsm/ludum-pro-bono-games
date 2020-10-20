using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManagerSnakeMath : MonoBehaviour {
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button resumeButton;
    [SerializeField] Button menuButton;
    private float pauseAnimationLength;
    private bool paused = false;

    private void Start() {
        pauseMenu.SetActive(false);
        Animator animator = pauseMenu.GetComponent<Animator>();
        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0];
        pauseAnimationLength = animationClip.length;

        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(() => SceneRouter.OpenGameMenu("SnakeMath"));
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            if (paused) Resume();
            else Pause();
        }
    }

    private void Pause() {
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume() {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
