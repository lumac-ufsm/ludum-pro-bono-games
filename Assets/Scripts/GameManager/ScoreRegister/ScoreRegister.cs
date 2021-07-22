using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegister : MonoBehaviour {
	[SerializeField] private InputField registrationNumberInput;
	[SerializeField] private Button registerButton;

	private void Start() {
		registerButton.onClick.AddListener(OnClickRegister);
	}

	private void OnClickRegister() {
		GameName currentGameName = GameManager.currentGameName;
		string registrationNumber = registrationNumberInput.text;
		NewScore newScore = new NewScore(
			gameId: (int)currentGameName,
			score: 2000,
			registrationNumber: registrationNumber,
			institutionName: "UFSM"
		);
		StartCoroutine(ScoreClient.AddScore(newScore, isSuccessful => {
			if (isSuccessful) {
				Destroy(gameObject);
			}
		}));
	}
}
