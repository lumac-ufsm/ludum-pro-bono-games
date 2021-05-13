using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButtonTheLostBrains : InteractiveMonoBehaviourTheLostBrains {
	private Animator animator;
	[SerializeField] private ControlledActivationMonoBehaviour[] controlledActivations;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public override void OnInteract(CharacterTheLostBrains character) {
		animator.Play("Press");
		foreach (var controlledActivation in controlledActivations) {
			controlledActivation.On();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			var character = other.gameObject.GetComponent<PlayerTheLostBrains>().character;
			EnableInteract(character);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			var character = other.gameObject.GetComponent<PlayerTheLostBrains>().character;
			DisableInteract(character);
		}
	}
}
