using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPacmaze : MonoBehaviour {
    [SerializeField] private GameObject otherPortal;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.transform.position != transform.position) {
                other.transform.position = otherPortal.transform.position;
            }
        }
    }
}
