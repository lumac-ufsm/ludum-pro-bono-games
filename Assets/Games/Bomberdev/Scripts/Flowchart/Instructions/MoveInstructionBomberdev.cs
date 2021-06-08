using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstructionBomberdev : MonoBehaviour {
	[SerializeField] private int _numberOfSteps = 1;
	[SerializeField] private Text txtOfSteps;

	public int numberOfSteps {
		get { return _numberOfSteps; }
	}

	void Start() {
		if (_numberOfSteps == 1){
			txtOfSteps.text = "";
		} else {
			txtOfSteps.text = ((char)_numberOfSteps);
		}
	}
}
