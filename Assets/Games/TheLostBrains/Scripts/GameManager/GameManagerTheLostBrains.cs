using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTheLostBrains : MonoBehaviour {
    public static GameObject GetGameObject() {
        return GameObject.Find("GameManagerTheLostBrains");
    }
    public static GameManagerTheLostBrains Get() {
        return GameObject.Find("GameManagerTheLostBrains").GetComponent<GameManagerTheLostBrains>();
    }
}
