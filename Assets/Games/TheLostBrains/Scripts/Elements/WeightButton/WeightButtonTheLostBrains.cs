using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButtonTheLostBrains : MonoBehaviour {
	[SerializeField] ControlledActivationMonoBehaviour[] controlledActivations;

	public void On() {
		foreach (var controlledActivation in controlledActivations) {
			controlledActivation.On();
		}
	}

	public void Off() {
		foreach (var controlledActivation in controlledActivations) {
			controlledActivation.Off();
		}
	}
}
