﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortalBomberdev : MonoBehaviour {
    private GameManagerBomberdev gameManager;

    private void Start() {
        gameManager = GameManagerBomberdev.Get();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            gameManager.OnFinishLevel();
        }
    }
}
