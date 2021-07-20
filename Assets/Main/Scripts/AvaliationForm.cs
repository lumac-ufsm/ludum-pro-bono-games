using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvaliationForm : MonoBehaviour {

    private void Start() {
        Button formButton = GetComponent<Button>();
        formButton.onClick.AddListener(OpenAvaliation);
    }

    private void OpenAvaliation() {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSfPTezOEJSxiApqnPoUhZ_Z4-w6UfoSzqyN-kC4cBjhGSOrSw/viewform?usp=sf_link");
    }
}