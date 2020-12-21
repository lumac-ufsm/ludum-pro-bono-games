using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPacmaze : MonoBehaviour {
    [SerializeField] private GameObject otherPortal;
    private static bool teleportAllowed = true;
    private void OnTriggerEnter2D(Collider2D other) {
        Vector2 position = gameObject.transform.position;
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = otherPortal.transform.position;
            gameObject.transform.position = otherPortal.transform.position;
            otherPortal.transform.position = position;
        }
    }
}
