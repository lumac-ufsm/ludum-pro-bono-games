using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTheLostBrains : ControlledActivationMonoBehaviour {
	private bool _isActive = false;
	public bool isActive {
		get => _isActive;
	}

	public override void On() {
		_isActive = true;
	}

	public override void Off() {
		_isActive = false;
	}
}
