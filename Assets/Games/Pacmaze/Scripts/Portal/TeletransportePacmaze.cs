using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportePacmaze : MonoBehaviour {
    
    [SerializeField] private GameObject otherPortal;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = otherPortal.transform.position;
        }
    }
}
