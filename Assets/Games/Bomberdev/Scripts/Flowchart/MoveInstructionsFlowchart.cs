using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstructionsFlowchart : MonoBehaviour {
    private List<Flowchart> flowcharts;
    private void Start() {
        foreach (Transform child in transform) {
            flowcharts.Add(child.gameObject.GetComponent<Flowchart>());
            
        }
    }
}
