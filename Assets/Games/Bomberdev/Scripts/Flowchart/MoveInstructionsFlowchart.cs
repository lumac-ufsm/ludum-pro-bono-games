using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstructionsFlowchart : MonoBehaviour {
    private List<GameObject> flowcharts = new List<GameObject>();
    private void Start() {
        foreach (Transform child in transform) {
            flowcharts.Add(child.gameObject);
        }
    }
}
