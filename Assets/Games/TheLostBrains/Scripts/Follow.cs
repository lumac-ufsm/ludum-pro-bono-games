using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public Transform followTransform;
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = true;
    [SerializeField] private float offsetY = 0f;
    [SerializeField] private float offsetX = 0f;

    void Start() {
        
    }

    float GetNextPosition(float position, float offset) {
        return position + offset;
    }

    void Update() {
        Vector3 position = transform.position;
        if (followX) {
            position.x = GetNextPosition(followTransform.position.x, offsetX);
        }
        if (followY) {
            position.y = GetNextPosition(followTransform.position.y, offsetY);
        }
        transform.position = position;
    }
}
