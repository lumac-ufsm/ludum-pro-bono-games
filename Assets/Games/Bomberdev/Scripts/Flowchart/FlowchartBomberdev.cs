using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartBomberdev : MonoBehaviour {
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
            if (instruction.GetComponent<InstructionBomberdev>() != null) {
                _instructions.Add(instruction);
            }
        }
    }
}
