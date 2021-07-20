using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerBomberdev : MonoBehaviour {
	private RunCommandsBomberdev runCommandsBomberdev;
	[SerializeField] private int nextLevelScore = 0;
	[SerializeField] private int numberOfInstructionsSensibility = 0;
	[SerializeField] private int timeCountSensibility = 0;

	private void Start() {
		runCommandsBomberdev = GameManagerBomberdev.Get().GetComponent<RunCommandsBomberdev>();
	}

	public int GetScore() {
		float numberOfInstructions = runCommandsBomberdev.flowchartRun.instructions.Count;
		float timeCount = Mathf.RoundToInt(TimeCountBomberdev.timeCount);
		float sn = numberOfInstructionsSensibility;
		float st = timeCountSensibility;
		float score = nextLevelScore + (sn / numberOfInstructions) + (st / timeCount);
		return Mathf.RoundToInt(score);
	}
}
