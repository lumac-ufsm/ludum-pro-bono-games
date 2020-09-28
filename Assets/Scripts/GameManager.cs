using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    void Start() {
        Cursor.visible = false;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            SceneManager.LoadScene("Main/Scenes/Main");
        }
    }
}
