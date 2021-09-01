using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationGames : MonoBehaviour {
	[SerializeField] private Button formButton;
	[SerializeField] private Button returnButton;

	private void Start() {
		gameObject.SetActive(true);
		formButton.onClick.AddListener(OpenEvaluation);
		returnButton.onClick.AddListener(CloseEvaluation);
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.back)) {
			CloseEvaluation();
		}
		if (Input.GetKeyDown(Keys.start)) {
			OpenEvaluation();
		}
	}

	private void CloseEvaluation() {
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	private void OpenEvaluation() {
		gameObject.SetActive(false);
		Time.timeScale = 1;
		Application.OpenURL(EvaluationForm.EVALUATION_FORM_URL);
	}
}
