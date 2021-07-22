using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRegisterManager : MonoBehaviour {
	[SerializeField] private GameObject _scoreRegisterPrefab;
	public GameObject scoreRegisterPrefab {
		get { return _scoreRegisterPrefab; }
	}

	public void InstantiateScoreRegisterPanel() {
		Instantiate(scoreRegisterPrefab);
	}
}
