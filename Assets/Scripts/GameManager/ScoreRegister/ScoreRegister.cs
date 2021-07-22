using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegister : MonoBehaviour {
	[SerializeField] private InputField registrationNumberInput;
	[SerializeField] private Button registerButton;

	private void Start() {
		registerButton.onClick.AddListener(() => {
			string registrationNumber = registrationNumberInput.text;
			print(registrationNumber);
		});
	}
}
