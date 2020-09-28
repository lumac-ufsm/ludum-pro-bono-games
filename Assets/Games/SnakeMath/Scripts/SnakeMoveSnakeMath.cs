using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMoveSnakeMath : MonoBehaviour {
    private SnakeSnakeMath snake;
    private bool allowedChangeDirection;
    private Vector2 direction;
    private float timeMove;
    [SerializeField] private float speedMove = 10;

    void Start() {
        snake = GetComponent<SnakeSnakeMath>();
    }

    void Update() {
        if (allowedChangeDirection) {
            if (Input.GetKeyDown(Keys.left) && direction.x <= 0) {
                direction = Vector3.left;
                allowedChangeDirection = false;
            }
            else if (Input.GetKeyDown(Keys.right) && direction.x >= 0) {
                direction = Vector3.right;
                allowedChangeDirection = false;
            }
            else if (Input.GetKeyDown(Keys.up) && direction.y >= 0) {
                direction = Vector3.up;
                allowedChangeDirection = false;
            }
            else if (Input.GetKeyDown(Keys.down) && direction.y <= 0) {
                direction = Vector3.down;
                allowedChangeDirection = false;
            }
        }

        timeMove += Time.deltaTime;
        if (timeMove >= 1 / speedMove) {
            timeMove = 0;
            snake.Move(direction);
            allowedChangeDirection = true;
        }
    }
}
