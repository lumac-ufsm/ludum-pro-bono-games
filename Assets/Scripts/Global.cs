using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {
    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            SceneManager.LoadScene("Main/Scenes/Main");
        }
    }
}
