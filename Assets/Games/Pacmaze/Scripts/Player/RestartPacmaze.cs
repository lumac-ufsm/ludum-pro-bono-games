using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPacmaze : MonoBehaviour {
    private Vector2 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.D)){
            gameObject.transform.position = initialPosition;
        }
    }
}
