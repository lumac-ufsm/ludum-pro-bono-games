using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerTheLostBrains : MonoBehaviour {
    [SerializeField] private GameObject[] players;
    [SerializeField] public CharacterTheLostBrains selectedCharacter;
    [SerializeField] public CharacterTheLostBrains[] allCharacters = {
        CharacterTheLostBrains.ENGINEER,
        CharacterTheLostBrains.HACKER,
        CharacterTheLostBrains.SCIENTIST
    };

    void Start() {
        selectedCharacter = CharacterTheLostBrains.ENGINEER;
    }

    void Update() {
        if (Input.GetKeyDown(Keys.action1)) {
            toggleCharacter();
        }
    }

    void toggleCharacter() {
        int index = Array.IndexOf(allCharacters, selectedCharacter) + 1;
        if (index >= allCharacters.Length) index = 0;
        selectedCharacter = allCharacters[index];
    }
}
