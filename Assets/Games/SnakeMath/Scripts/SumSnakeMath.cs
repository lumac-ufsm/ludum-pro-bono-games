using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumSnakeMath : MonoBehaviour {
    public static int sum = 0;
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    private void Update() {
        text.text = sum.ToString();
    }
}
