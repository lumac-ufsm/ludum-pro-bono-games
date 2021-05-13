using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTheLostBrains : MonoBehaviour {
	private PlayerManagerTheLostBrains playerManager;

	private void Start() {
		playerManager = GetComponent<PlayerManagerTheLostBrains>();
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.action4)) {
			playerManager.toggleCharacter();
		}
	}

	public static GameObject GetGameObject() {
		return GameObject.Find("GameManagerTheLostBrains");
	}

	public static GameManagerTheLostBrains Get() {
		return GameObject.Find("GameManagerTheLostBrains").GetComponent<GameManagerTheLostBrains>();
	}
}
