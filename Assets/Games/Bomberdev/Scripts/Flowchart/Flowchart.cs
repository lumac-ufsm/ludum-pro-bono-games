using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowchart : MonoBehaviour {
    private List<GameObject> _instructions;
    public List<GameObject> instructions {
        get {
            if (_instructions == null) {
                UpdateInstructions();
            }
            return _instructions;
        }
    }

    private void UpdateInstructions() {
        _instructions = new List<GameObject>();
        foreach (Transform child in transform) {
            GameObject instruction = child.gameObject;
            if (instruction.GetComponent<Instruction>() != null) {
                _instructions.Add(instruction);
            }
        }
    }
}
