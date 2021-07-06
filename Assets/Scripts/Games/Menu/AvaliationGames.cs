using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvaliationGames : MonoBehaviour {
    [SerializeField] private Button formButton;
    [SerializeField] private Button returnButton;

    private void Start() {
        gameObject.SetActive(true);

        formButton.onClick.AddListener(OpenAvaliation);
        returnButton.onClick.AddListener(CloseAvaliation);

        Time.timeScale = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.back)) {
            CloseAvaliation();
        }
        if (Input.GetKeyDown(Keys.start)) {
            OpenAvaliation();
        }
    }

    private void CloseAvaliation() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OpenAvaliation() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Application.OpenURL("https://www.google.com/");
    }
}
