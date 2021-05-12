using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonTheLostBrains : MonoBehaviour {
	[SerializeField] private WeightButtonTheLostBrains weightButton;
	[SerializeField] private bool isPressed = false;
	[SerializeField] private bool isShortPressed = false;
	[SerializeField] private float buttonPressTime;
	private float timeCount = 0;

	void Start() {

	}

	void Update() {
		if (isShortPressed) {
			if (timeCount < buttonPressTime) {
				timeCount += Time.deltaTime;
				isPressed = false;
				weightButton.Off();
			} else {
				isPressed = true;
				weightButton.On();
			}
		} else {
			isPressed = false;
			weightButton.Off();
			timeCount = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "PressPoint") {
			isShortPressed = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "PressPoint") {
			isShortPressed = false;
		}
	}
}
