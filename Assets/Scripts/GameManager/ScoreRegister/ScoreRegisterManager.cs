using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRegisterManager : MonoBehaviour {
	[SerializeField] private GameObject _scoreRegisterPrefab;
	private static int _score = 0;
	public static int score { get { return _score; } }
	public GameObject scoreRegisterPrefab {
		get { return _scoreRegisterPrefab; }
	}

	public void OpenScoreRegisterPanel(int score) {
		ScoreRegisterManager._score = score;
		Instantiate(scoreRegisterPrefab);
	}
}
