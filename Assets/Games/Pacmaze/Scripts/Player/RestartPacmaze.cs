using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPacmaze : MonoBehaviour {
    private Vector2 initialPosition;
    private Rigidbody2D rigidbodyPacmaze;

    private void Start() {
        initialPosition = transform.position;
        rigidbodyPacmaze = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetKeyDown(Keys.action4)){
            gameObject.transform.position = initialPosition;
            rigidbodyPacmaze.velocity = Vector2.zero;
        }
    }
}
