using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodsManagerSnakeMath : MonoBehaviour {
    [SerializeField] private GameObject[] foodPrefabs;
    private GameAreaSnakeMath gameArea;
    private SnakeSnakeMath snake;
    private List<GameObject> foods;
    
    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
        gameArea = GameObject.Find("GameArea").GetComponent<GameAreaSnakeMath>();
        foods = new List<GameObject>();
        CreateFood(foodPrefabs[0], 4);
        CreateFood(foodPrefabs[1], 4);
        CreateFood(foodPrefabs[2], 4);
        CreateFood(foodPrefabs[3], 3);
        CreateFood(foodPrefabs[4], 3);
        CreateFood(foodPrefabs[5], 2);
        CreateFood(foodPrefabs[6], 2);
        CreateFood(foodPrefabs[7], 1);
    }

    public void CreateFood(GameObject foodPrefab, int num=1) {
        for (int n = 0; n < num; n++) {
            Vector2 position = SortPositionFood(GetInvalidPositions());
            GameObject food = Instantiate(foodPrefab, position, Quaternion.identity);
            foods.Add(food);
        }
    }

    public Vector2[] GetInvalidPositions() {
        List<Vector2> invalidPositions = new List<Vector2>(); 
        IEnumerable<Vector2> snakePositions = snake.bodyList.Select(body => (Vector2) body.transform.position);
        IEnumerable<Vector2> foodsPositions = foods.Select(food => (Vector2) food.transform.position);
        invalidPositions.Add(snake.transform.position);
        return invalidPositions.Concat(snakePositions).Concat(foodsPositions).ToArray();
    }

    public Vector2 SortPositionFood(Vector2[] invalidPositions) {
        Vector2 position;
        do {
            position = new Vector2(
                Mathf.Round(Random.Range(gameArea.minX, gameArea.maxX)),
                Mathf.Round(Random.Range(gameArea.minY, gameArea.maxY))
            );
        } while (invalidPositions.Contains(position));
        return position;
    }
}
