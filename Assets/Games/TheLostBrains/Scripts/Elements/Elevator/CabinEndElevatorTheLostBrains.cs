using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinEndElevatorTheLostBrains : MonoBehaviour {
	private enum CabinEnd {
		TOP,
		BOTTOM
	}

	[SerializeField] private MoveElevatorCabinTheLostBrains moveElevatorCabin;
	[SerializeField] private CabinEnd cabinEnd;

	private void OnCollisionEnter2D(Collision2D other) {
		if (cabinEnd == CabinEnd.TOP) {
			moveElevatorCabin.OnColliderEnterTop();
		} else if (cabinEnd == CabinEnd.BOTTOM) {
			moveElevatorCabin.OnColliderEnterBottom();
		}
	}
}
