using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTheLostBrains : MonoBehaviour {
    private GameObject gameManager;
    private PlayerManagerTheLostBrains playerManager;
    public CharacterTheLostBrains character;
    public bool isSelected {
        get => playerManager.selectedCharacter == character;
    }

    void Start() {
        gameManager = GameObject.Find("GameManagerTheLostBrains");
        playerManager = gameManager.GetComponent<PlayerManagerTheLostBrains>();
    }
}
