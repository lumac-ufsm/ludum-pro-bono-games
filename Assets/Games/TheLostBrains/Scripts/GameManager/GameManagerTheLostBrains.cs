using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTheLostBrains : MonoBehaviour {
	private PlayerManagerTheLostBrains playerManager;
	public List<InteractiveMonoBehaviourTheLostBrains> interactiveElements;

	private void Start() {
		playerManager = GetComponent<PlayerManagerTheLostBrains>();
	}

	private void Update() {
		if (Input.GetKeyDown(Keys.action4)) {
			playerManager.toggleCharacter();
		}
		if (Input.GetKeyDown(Keys.action1)) {
			Interact();
		}
	}

	private void Interact() {
		foreach (var interactiveElement in interactiveElements) {
			interactiveElement.Interact(playerManager.selectedCharacter);
		}
	}

	public static GameObject GetGameObject() {
		return GameObject.Find("GameManagerTheLostBrains");
	}

	public static GameManagerTheLostBrains Get() {
		return GameObject.Find("GameManagerTheLostBrains").GetComponent<GameManagerTheLostBrains>();
	}
}
