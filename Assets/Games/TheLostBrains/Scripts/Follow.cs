using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public Transform followTransform;
	[SerializeField] private bool followX = true;
	[SerializeField] private bool followY = true;
	[SerializeField] private float offsetY = 0f;
	[SerializeField] private float offsetX = 0f;
	[SerializeField] private float smoothLevel = 0f;

	private float GetNextPosition(float currentPosition, float nextPosition, float offset) {
		return Mathf.Lerp(nextPosition + offset, currentPosition, smoothLevel / 100);
	}

	private void LateUpdate() {
		Vector3 position = transform.position;
		if (followX) {
			position.x = GetNextPosition(transform.position.x, followTransform.position.x, offsetX);
		}
		if (followY) {
			position.y = GetNextPosition(transform.position.y, followTransform.position.y, offsetY);
		}
		transform.position = position;
	}
}
