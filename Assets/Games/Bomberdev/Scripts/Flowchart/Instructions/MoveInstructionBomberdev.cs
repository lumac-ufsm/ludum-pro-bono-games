using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveInstructionBomberdev : MonoBehaviour {
	[SerializeField] private Text txtOfSteps;
	private int _numberOfSteps = 1;

	public int numberOfSteps {
		get { return _numberOfSteps; }
	}

	void Start() {
		if (txtOfSteps.text != "") {
			this._numberOfSteps = int.Parse(txtOfSteps.text);
		}
	}
}
