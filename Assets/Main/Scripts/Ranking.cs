using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour {
	[SerializeField] private GameSelectorManager gameSelectorManager;
	[SerializeField] private TextMeshPro rankingTextMeshPro;
	private GameName gameName;

	private void Start() {
		gameName = gameSelectorManager.gameName;
		UpdateRanking();
	}

	private void UpdateRanking() {
		StartCoroutine(ScoreClient.GetTopScores((int)gameName, scores => {
			if (scores.Length == 0) {
				rankingTextMeshPro.text = "Sem pontuações";
			} else {
				string rankingText = "";
				foreach (Score score in scores) {
					string name = score.user.name;
					int scoreNumber = score.score;
					string institutionName = score.user.institution.name;
					rankingText += $"{institutionName} {name} {scoreNumber}\n";
				}
				rankingTextMeshPro.text = rankingText;
			}
		}));
	}
}
