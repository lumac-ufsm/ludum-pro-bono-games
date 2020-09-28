using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSnakeMath : MonoBehaviour {
    [SerializeField] private int _value;
    public int value { get { return _value; } }
    private FoodsManagerSnakeMath foodsManager;
    
    private void Start() {
        foodsManager = GameObject.Find("GameManagerSnakeMath").GetComponent<FoodsManagerSnakeMath>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Reposition();
        }
    }

    private void Reposition() {
        Vector2[] invalidPositions = foodsManager.GetInvalidPositions();
        transform.position = foodsManager.SortPositionFood(invalidPositions);
    }
}
