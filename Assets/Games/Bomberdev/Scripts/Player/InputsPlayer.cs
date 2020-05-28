using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsPlayer : MonoBehaviour {
    private Move move;
    
    private void Start() {
        move = GetComponent<Move>();
    }

    private void Update() {
        InputMove();
    }

    private void InputMove() {
        if (Input.GetKeyDown(Keys.up)) move.Translate(Direction.UP);
        if (Input.GetKeyDown(Keys.down)) move.Translate(Direction.DOWN);
        if (Input.GetKeyDown(Keys.left)) move.Translate(Direction.LEFT);
        if (Input.GetKeyDown(Keys.right)) move.Translate(Direction.RIGHT);
    }
}
