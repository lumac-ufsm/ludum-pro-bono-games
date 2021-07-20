using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManagerBomberdev : MonoBehaviour {
	private RunCommandsBomberdev runCommandsBomberdev;
	[SerializeField] private int nextLevelPoints = 0;
	[SerializeField] private int numberOfInstructionsSensibility = 0;
	[SerializeField] private int timeCountSensibility = 0;

	private void Start() {
		runCommandsBomberdev = GameManagerBomberdev.Get().GetComponent<RunCommandsBomberdev>();
		print("teste");
	}

	public int GetPoints() {
		float numberOfInstructions = runCommandsBomberdev.flowchartRun.instructions.Count;
		float timeCount = Mathf.RoundToInt(TimeCountBomberdev.timeCount);
		float sn = numberOfInstructionsSensibility;
		float st = timeCountSensibility;
		sn = 0;
		nextLevelPoints = 0;
		float points = nextLevelPoints + (sn / numberOfInstructions) + (st / timeCount);
		return Mathf.RoundToInt(points);
	}
}
