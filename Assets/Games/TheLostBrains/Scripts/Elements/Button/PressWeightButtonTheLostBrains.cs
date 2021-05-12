using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressWeightButtonTheLostBrains : MonoBehaviour {
	[SerializeField] private WeightButtonTheLostBrains weightButton;
	[SerializeField] private bool isPressed = false;
	[SerializeField] private bool isShortPressed = false;
	[SerializeField] private float buttonPressTime;
	private float timeCount = 0;

	void Start() {

	}

	void Update() {
		bool oldIsPressed = isPressed;
		if (isShortPressed) {
			if (timeCount < buttonPressTime) {
				timeCount += Time.deltaTime;
				isPressed = false;
			} else {
				isPressed = true;
			}
		} else {
			isPressed = false;
			timeCount = 0;
		}
		if (oldIsPressed != isPressed) {
			if (isPressed) weightButton.On();
			else weightButton.Off();
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
