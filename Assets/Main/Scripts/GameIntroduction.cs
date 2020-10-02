using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntroduction : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            SceneManager.LoadScene($"Games/{GameManager.currentGame}/Scenes/Main"); 
        }
    }
} 
