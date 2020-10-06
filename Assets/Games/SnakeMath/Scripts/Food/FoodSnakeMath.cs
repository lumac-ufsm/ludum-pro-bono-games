using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSnakeMath : MonoBehaviour {
    [SerializeField] private int _value;
    public int value { get { return _value; } }
    private FoodsManagerSnakeMath foodsManager;
    private EquationManagerSnakeMath equationManager;
    
    private void Start() {
        GameObject gameManager = GameObject.Find("GameManagerSnakeMath");
        foodsManager = gameManager.GetComponent<FoodsManagerSnakeMath>();
        equationManager = gameManager.GetComponent<EquationManagerSnakeMath>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Reposition();
            AddFoodValueInSum();
            equationManager.OnColliderFood();
        }
    }

    private void Reposition() {
        Vector2[] invalidPositions = foodsManager.GetInvalidPositions();
        transform.position = foodsManager.SortPositionFood(invalidPositions);
    }

    private void AddFoodValueInSum() {
        if (value == 0) SumSnakeMath.sum = 0;
        else SumSnakeMath.sum += value;
    }
}
