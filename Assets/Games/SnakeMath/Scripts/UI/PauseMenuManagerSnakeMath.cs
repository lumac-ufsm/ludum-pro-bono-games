using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManagerSnakeMath : MonoBehaviour {
    [SerializeField] GameObject pauseMenu;

    private void Start() {
        pauseMenu.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) Pause();
    }

    private void Pause() {
        pauseMenu.SetActive(true);
        GameManager.instance.WaitForSeconds(1, () => {
            Time.timeScale = 0;
        });
    }

    private void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
