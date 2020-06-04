using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTriggerBombBomberdev : MonoBehaviour {
    [SerializeField] private Collider2D collider2D;

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            collider2D.isTrigger = false;
        }
    }
}
