using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevatorCabinTheLostBrains : MonoBehaviour {
	[SerializeField] private ElevatorTheLostBrains elevator;
	[SerializeField] private float modSpeed = 0;
	[SerializeField] private float breakTime = 0;
	[SerializeField] private ElevatorStateTheLostBrains state;
	private bool allowToggleDirectionOnColideBottom = true;
	private float breakTimeCount = 0;
	private bool isStopped = true;

	void Update() {
		if (elevator.isActive) {
			if (breakTimeCount > 0) {
				breakTimeCount -= Time.deltaTime;
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
			allowToggleDirectionOnColideBottom = false;
			state = ElevatorStateTheLostBrains.DOWN;
			if (oldState != state) breakTimeCount = breakTime;
		} else if (other.gameObject.name == "BottomPoint") {
			allowToggleDirectionOnColideBottom = false;
			state = ElevatorStateTheLostBrains.UP;
			if (oldState != state) breakTimeCount = breakTime;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "TopPoint" || other.gameObject.name == "BottomPoint") {
			allowToggleDirectionOnColideBottom = true;
		}
	}

	public void OnColliderEnterTop() {
	}

	public void OnColliderEnterBottom() {
		if (allowToggleDirectionOnColideBottom) {
			state = ElevatorStateTheLostBrains.UP;
		}
	}
}
