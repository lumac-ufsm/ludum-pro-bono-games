using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private List<Vector2> queuePositions = new List<Vector2>();
    private Vector2 oldPosition;

    private void Start() {
        oldPosition = transform.position;
    }

    private void Update() {
        Run();
    }

    public void Translate(Direction direction) {
        Vector2 translate = Vector2.zero;
        switch(direction) {
            case Direction.UP:
                translate = new Vector2(0, 1);
                break;
            case Direction.DOWN:
                translate = new Vector2(0, -1);
                break;
            case Direction.LEFT:
                translate = new Vector2(-1, 0);
                break;
            case Direction.RIGHT:
                translate = new Vector2(1, 0);
                break;
        }

        Vector2 position;
        if (queuePositions.Count > 0) {
            position = queuePositions[queuePositions.Count - 1] + translate;
        } else {
            position = ((Vector2) transform.position) + translate;
        }
        queuePositions.Add(position);
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
