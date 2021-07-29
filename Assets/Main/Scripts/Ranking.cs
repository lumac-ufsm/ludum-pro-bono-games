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
					int scoreNumber = score.score;
					if (score.user.id != 0) {
						string userName = score.user.name;
						string institutionName = score.user.institution.name;
						rankingText += $"{institutionName} {userName} {scoreNumber}\n";
					} else {
						rankingText += $"{score.playerName} {scoreNumber}\n";
					}
				}
				rankingTextMeshPro.text = rankingText;
			}
		}));
	}
}
