using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountBomberdev : MonoBehaviour {
	private static float _timeCount = 0f;
	public static float timeCount {
		get { return _timeCount; }
	}

	void Update() {
		_timeCount += Time.deltaTime;
	}

	public static void ResetTimeCount() {
		_timeCount = 0f;
	}
}
