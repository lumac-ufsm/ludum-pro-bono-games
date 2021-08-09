using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerPacmaze : MonoBehaviour {
	public int moveCount;
	[SerializeField] private int nextLevelScore = 0;
	[SerializeField] private int numberOfMoveSensibility = 0;
	[SerializeField] private int timeCountSensibility = 0;

	private void Start() {
	}

	public int GetScore() {
		float numberOfMovements = moveCount;
		float timeCount = Mathf.RoundToInt(TimeCountPacmaze.timeCount);
		float sn = numberOfMoveSensibility;
		float st = timeCountSensibility;
		float score = nextLevelScore + (sn / numberOfMovements) + (st / timeCount);
		return Mathf.RoundToInt(score);
	}
}
