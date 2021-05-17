using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDoorTheLostBrains : ControlledActivationMonoBehaviour {
	[SerializeField] private float modOpenSpeed;
	private bool isOpen = false;
	private float maxScale;

	private void Start() {
		maxScale = transform.localScale.y;
	}

	private void Update() {
		Vector2 scale = transform.localScale;
		float deltaY = Time.deltaTime * modOpenSpeed;
		float y = scale.y + (isOpen ? -1 : 1) * deltaY;
		y = Mathf.Max(y, 0);
		y = Mathf.Min(y, maxScale);
		transform.localScale = new Vector2(scale.x, y);
	}

	public override void On() {
		isOpen = true;
	}

	public override void Off() {
		isOpen = false;
	}
}
