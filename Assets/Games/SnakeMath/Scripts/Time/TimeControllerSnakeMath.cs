using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerSnakeMath : MonoBehaviour {
    private Text timeText;
    public static int time;

    private void Start() {
        timeText = gameObject.GetComponent<Text>();
    }

    private void Update() {
        timeText.text = time.ToString();
    }
}
