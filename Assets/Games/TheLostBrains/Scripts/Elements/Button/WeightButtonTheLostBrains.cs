using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButtonTheLostBrains : MonoBehaviour {
	[SerializeField] ControlledActivationMonoBehaviour controlledActivation;

	public void On() {
		controlledActivation.On();
	}

	public void Off() {
		controlledActivation.Off();
	}
}
