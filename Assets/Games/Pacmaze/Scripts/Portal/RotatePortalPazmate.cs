using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePortalPazmate : MonoBehaviour {
    [SerializeField] private float speedRotation = 1f;
    private void Update() {
        transform.Rotate(new Vector3(0, 0, -speedRotation * Time.deltaTime));
    }
}
