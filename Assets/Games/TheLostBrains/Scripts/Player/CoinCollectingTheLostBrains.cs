using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectingTheLostBrains : MonoBehaviour {
    private int coins = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.StartsWith("Coin")) {
            coins++;
            Destroy(other.gameObject);
        }
    }
}
