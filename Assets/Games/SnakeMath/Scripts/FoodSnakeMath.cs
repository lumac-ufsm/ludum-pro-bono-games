using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodSnakeMath : MonoBehaviour {
    [SerializeField] private int _value;
    public int value { get { return _value; } }
    private SnakeSnakeMath snake;
    private GameAreaSnakeMath gameArea;

    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
        gameArea = GameObject.Find("GameArea").GetComponent<GameAreaSnakeMath>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Reposition();
        }
    }

    private void Reposition() {
        var snakePositions = snake.bodyList.Select(body => (Vector2) body.transform.position);
        Vector2[] invalidPositions = snakePositions.ToArray();
        transform.position = SortPositionFood(invalidPositions);
    }

    private Vector2 SortPositionFood(Vector2[] invalidPositions) {
        Vector2 position;
        do {
            position = new Vector2(
                Mathf.Round(Random.Range(gameArea.minX, gameArea.maxX)),
                Mathf.Round(Random.Range(gameArea.minY, gameArea.maxY))
            );
        } while (position == null || invalidPositions.Contains(position));
        return position;
    }
}
