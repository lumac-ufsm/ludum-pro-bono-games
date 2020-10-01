using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationManagerSnakeMath : MonoBehaviour {
    private List<EquationSnakeMath> equations;
    private SnakeSnakeMath snake;
    private int difficulty = 1;
    private EquationSnakeMath currentEquation;

    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
        equations = new List<EquationSnakeMath>();
        equations.Add(new SumEquationSnakeMath());
        CreateEquation();
    }

    public void OnColliderFood() {
        if (SumSnakeMath.sum == currentEquation.result) {
            snake.AddBody();
            CreateEquation();
            SumSnakeMath.sum = 0;
            difficulty++;
        }
    }

    private void CreateEquation() {
        currentEquation = GetRandomEquation();
        currentEquation.CreateEquation(difficulty);
        EquationControllerSnakeMath.equationRepresentation = currentEquation.representation;
    }

    private EquationSnakeMath GetRandomEquation() {
        int max = equations.Count;
        int index = Random.Range(0, max);
        return equations[index];
    }
}
