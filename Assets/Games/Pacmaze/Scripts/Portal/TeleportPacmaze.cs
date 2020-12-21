using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPacmaze : MonoBehaviour {
    [SerializeField] private GameObject otherPortal;
    private static bool teleportAllowed = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (teleportAllowed) {
                other.transform.position = otherPortal.transform.position;
                teleportAllowed = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        teleportAllowed = true;
        // print("Saiu da colisão");
    }
}
