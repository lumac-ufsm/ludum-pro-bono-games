using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMoveSnakeMath : MonoBehaviour {
    private SnakeSnakeMath snake;
    private bool allowedChangeDirection;
    private Vector2 direction;
    private float timeMove;
    [SerializeField] private float speedMove = 10;
    [SerializeField] private GameObject gameAreaGameObject;
    private GameAreaSnakeMath gameArea;

    void Start() {
        snake = GetComponent<SnakeSnakeMath>();
        gameArea = gameAreaGameObject.GetComponent<GameAreaSnakeMath>();
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

        Vector3 position = transform.position;
        if (position.x < gameArea.minX) position.x = gameArea.maxX;
        else if (position.x > gameArea.maxX) position.x = gameArea.minX;
        else if (position.y < gameArea.minY) position.y = gameArea.maxY;
        else if (position.y > gameArea.maxY) position.y = gameArea.minY;
        transform.position = position;
    }
}
