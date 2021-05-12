using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevatorCabinTheLostBrains : MonoBehaviour {
	[SerializeField] private ElevatorTheLostBrains elevator;
	[SerializeField] private float modSpeed = 0;
	[SerializeField] private float breakTime = 0;
	[SerializeField] private ElevatorStateTheLostBrains state;
	private float timeCount = 0;
	private bool isStopped = true;

	void Update() {
		if (elevator.isActive) {
			if (timeCount > 0) {
				timeCount -= Time.deltaTime;
				isStopped = true;
			} else {
				isStopped = false;
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

	public void OnColliderEnterTop() {
		state = ElevatorStateTheLostBrains.DOWN;
	}

	public void OnColliderEnterBottom() {
		state = ElevatorStateTheLostBrains.UP;
	}
}
