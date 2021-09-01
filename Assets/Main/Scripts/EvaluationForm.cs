using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationForm : MonoBehaviour {
	public const string EVALUATION_FORM_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfPTezOEJSxiApqnPoUhZ_Z4-w6UfoSzqyN-kC4cBjhGSOrSw/viewform?usp=sf_link";

	private void Start() {
		Button formButton = GetComponent<Button>();
		formButton.onClick.AddListener(OpenEvaluation);
	}

	private void OpenEvaluation() {
		Application.OpenURL(EvaluationForm.EVALUATION_FORM_URL);
	}
}