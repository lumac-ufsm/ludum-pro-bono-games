using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTheLostBrains : ControlledActivationMonoBehaviour {
	[SerializeField] private GameObject _topPointGameObject;
	[SerializeField] private GameObject _bottomPointGameObject;
	private bool _isActive = false;
    
	public GameObject topPointGameObject { get => _topPointGameObject; }
	public GameObject bottomPointGameObject { get => _bottomPointGameObject; }
	public bool isActive { get => _isActive; }

	public override void On() {
		_isActive = true;
	}

	public override void Off() {
		_isActive = false;
	}
}
