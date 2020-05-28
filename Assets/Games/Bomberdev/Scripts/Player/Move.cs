using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    [SerializeField] private List<Vector2> queuePositions = new List<Vector2>();
    private Vector2 oldPosition;

    private void Start() {
        oldPosition = transform.position;
    }

    private void Update() {
        InputMove();
        Run();
    }

    private void InputMove() {
        if (Input.GetKeyDown(Keys.up)) EnqueuePosition(new Vector2(0, 1));
        if (Input.GetKeyDown(Keys.down)) EnqueuePosition(new Vector2(0, -1));
        if (Input.GetKeyDown(Keys.left)) EnqueuePosition(new Vector2(-1, 0));
        if (Input.GetKeyDown(Keys.right)) EnqueuePosition(new Vector2(1, 0));
    }

    private void EnqueuePosition(Vector2 move) {
        Vector2 position;
        if (queuePositions.Count > 0) {
            position = queuePositions[queuePositions.Count - 1] + move;
        } else {
            position = ((Vector2) transform.position) + move;
        }
        queuePositions.Add(position);
        print(position);
    }

    private void Run() {
        if (queuePositions.Count > 0) {
            Vector2 currentPosition = transform.position;
            if (currentPosition != queuePositions[0]) {
                transform.Translate((queuePositions[0] - oldPosition) * 0.1f);
            } else {
                oldPosition = currentPosition;
                queuePositions.RemoveAt(0);
            }
        }
    }
}
