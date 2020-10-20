using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance = null;
    public static string currentGame;
    public static GameManager instance { 
        get {
            if (_instance == null) {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<GameManager>();
                _instance = Instantiate(gameObject).GetComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Start() {
        StartRestart();
    }

    private void Restart() {
        StartRestart();
    }

    private void StartRestart() {
        // Cursor.visible = false;
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Restart();
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            SceneRouter.OpenMain();
            currentGame = null;
        }
    }

    public void WaitForSeconds(int seconds, Func.Callback callback) {
        IEnumerator Coroutine() {
            yield return new WaitForSeconds(seconds);
            callback();
        }
        StartCoroutine(Coroutine());
    }
}
