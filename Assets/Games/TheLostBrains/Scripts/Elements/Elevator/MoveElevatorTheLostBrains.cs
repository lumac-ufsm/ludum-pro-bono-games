using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevatorTheLostBrains : MonoBehaviour {
	[SerializeField] private ElevatorTheLostBrains elevator;
	[SerializeField] private float modSpeed = 0;
	[SerializeField] private float breakTime = 0;
	[SerializeField] private ElevatorStateTheLostBrains state;
	private float timeCount = 0;

	void Update() {
		if (elevator.isActive) {
			if (timeCount > 0) {
				timeCount -= Time.deltaTime;
			} else {
				float speed = GetSpeed();
				transform.Translate(new Vector2(0, speed * Time.deltaTime));
			}
		}
	}

	private float GetSpeed() {
		switch (state) {
			case ElevatorStateTheLostBrains.UP:
				return modSpeed;
			case ElevatorStateTheLostBrains.DOWN:
				return -modSpeed;
			default:
				return 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		ElevatorStateTheLostBrains oldState = state;
		if (other.gameObject.name == "TopPoint") {
			state = ElevatorStateTheLostBrains.DOWN;
			if (oldState != state) timeCount = breakTime;
		} else if (other.gameObject.name == "BottomPoint") {
			state = ElevatorStateTheLostBrains.UP;
			if (oldState != state) timeCount = breakTime;
		}
	}
}
