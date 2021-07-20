using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsBox : MonoBehaviour {
    [SerializeField] private Button continueButton;

    private void Start() {
        gameObject.SetActive(true);

        continueButton.onClick.AddListener(CloseInstruction);

        Time.timeScale = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.start)) {
            CloseInstruction();
        }
    }

    private void CloseInstruction() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
