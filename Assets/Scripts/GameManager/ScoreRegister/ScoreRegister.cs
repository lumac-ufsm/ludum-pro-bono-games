using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegister : MonoBehaviour {
	[SerializeField] private InputField registrationNumberInput;
	[SerializeField] private InputField playerNameInput;
	[SerializeField] private Button registerButton;

	private void Start() {
		registerButton.onClick.AddListener(OnClickRegister);
	}

	private void OnClickRegister() {
		GameName currentGameName = GameManager.currentGameName;
		int score = ScoreRegisterManager.score;
		string registrationNumber = registrationNumberInput.text;
		string playerName = playerNameInput.text;
		NewScore newScore = new NewScore(
			gameId: (int)currentGameName,
			score: score,
			registrationNumber: registrationNumber,
			institutionName: "UFSM",
			playerName: playerName
		);
		StartCoroutine(ScoreClient.AddScore(newScore, isSuccessful => {
			if (isSuccessful) {
				Destroy(gameObject);
			}
		}));
	}
}
