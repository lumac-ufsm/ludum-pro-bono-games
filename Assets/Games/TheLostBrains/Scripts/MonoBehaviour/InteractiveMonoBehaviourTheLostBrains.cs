using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveMonoBehaviourTheLostBrains : MonoBehaviour {
	private List<CharacterTheLostBrains> interactiveCharacters = new List<CharacterTheLostBrains>();
	private GameManagerTheLostBrains _gameManager;

	private GameManagerTheLostBrains gameManager {
		get {
			if (_gameManager == null) {
				_gameManager = GameManagerTheLostBrains.Get();
			}
			return _gameManager;
		}
	}

	protected void EnableInteract(CharacterTheLostBrains character) {
		if (!gameManager.interactiveElements.Contains(this)) {
			gameManager.interactiveElements.Add(this);
		}
		interactiveCharacters.Add(character);
	}

	protected void DisableInteract(CharacterTheLostBrains character) {
		if (interactiveCharacters.Count == 0 && gameManager.interactiveElements.Contains(this)) {
			gameManager.interactiveElements.Remove(this);
		}
		interactiveCharacters.Remove(character);
	}

	public void Interact(CharacterTheLostBrains character) {
		if (interactiveCharacters.Contains(character)) {
			OnInteract(character);
		}
	}

	public abstract void OnInteract(CharacterTheLostBrains character);
}
