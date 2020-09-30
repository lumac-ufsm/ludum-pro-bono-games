using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationControllerSnakeMath : MonoBehaviour {
    private Text equationText;
    public static string equationRepresentation;

    private void Start() {
        equationText = gameObject.GetComponent<Text>();
    }

    private void Update() {
        equationText.text = $"{equationRepresentation} = ?";
    }
}
