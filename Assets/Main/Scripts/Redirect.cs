using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redirect : MonoBehaviour {
    [SerializeField] public float time = 5;
    private float timeCounter = 0;
    private SelectGame selectGame;
    private string gameName;

    private void Start() {
        selectGame = GameObject.Find("GameManager").GetComponent<SelectGame>();
        gameName = selectGame.selectedGameName; 
    }

    void Update() {
        timeCounter += Time.deltaTime;
        print(timeCounter);
        if (timeCounter >= time) {
            SceneManager.LoadScene($"Games/{gameName}/Scenes/Main");
        }
    }
} 
