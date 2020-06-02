using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowchart : MonoBehaviour {
    private List<GameObject> instructions = new List<GameObject>();

    private void Start() {
        foreach (Transform child in transform) {
            GameObject instruction = child.gameObject;
            if (instruction.GetComponent<Instruction>()) {
                instructions.Add(instruction);
            }
        }

        print(instructions.Count);
    }
}
