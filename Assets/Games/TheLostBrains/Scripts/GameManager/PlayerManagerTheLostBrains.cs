using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerTheLostBrains : MonoBehaviour {
    [SerializeField] private GameObject[] allCharactersGameObject;
    [SerializeField] public CharacterTheLostBrains selectedCharacter;
    [SerializeField] public CharacterTheLostBrains[] allCharacters = {
        CharacterTheLostBrains.ENGINEER,
        CharacterTheLostBrains.HACKER,
        CharacterTheLostBrains.SCIENTIST
    };
    private Follow followCamera;

    void Start() {
        selectedCharacter = CharacterTheLostBrains.ENGINEER;
        followCamera = Camera.main.GetComponent<Follow>();
    }

    public GameObject GetSelectedCharacterGameObject() {
        foreach(GameObject characterGameObject in allCharactersGameObject) {
            PlayerTheLostBrains player = characterGameObject.GetComponent<PlayerTheLostBrains>();
            if (player.character == selectedCharacter) {
                return characterGameObject;
            }
        }
        return null;
    }

    public void toggleCharacter() {
        int index = Array.IndexOf(allCharacters, selectedCharacter) + 1;
        if (index >= allCharacters.Length) index = 0;
        selectedCharacter = allCharacters[index];
        followCamera.followTransform = GetSelectedCharacterGameObject().GetComponent<Transform>();
    }
}
