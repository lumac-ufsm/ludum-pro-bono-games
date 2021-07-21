using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerPacmaze : MonoBehaviour {
    private MovePacmaze movePacmaze;
    [SerializeField] private int nextLevelScore = 0;
	[SerializeField] private int numberOfInstructionsSensibility = 0;
	[SerializeField] private int timeCountSensibility = 0;

    private void Start() {
		movePacmaze = GetComponent<MovePacmaze>();
	}
    public int GetScore() {
		//float numberOfInstructions = movePacmaze.GetMove();
		float timeCount = Mathf.RoundToInt(TimeCountPacmaze.timeCount);
		float sn = numberOfInstructionsSensibility;
		float st = timeCountSensibility;
		float score = nextLevelScore + (sn / numberOfInstructions) + (st / timeCount);
		return Mathf.RoundToInt(score);
	}
}
