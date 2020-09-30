using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationManagerSnakeMath : MonoBehaviour {
    private EquationSnakeMath[] equations = {
        new SumEquationSnakeMath(),
        new SubtractEquationSnakeMath()
    };
    private SnakeSnakeMath snake;
    private int difficulty { get { return snake.bodyList.Count; } }
    private EquationSnakeMath equation;

    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
        CreateEquation();
    }

    public void OnColliderFood() {
        if (SumSnakeMath.sum == equation.result) {
            snake.AddBody(difficulty);
            CreateEquation();
            SumSnakeMath.sum = 0;
        }
    }

    private void CreateEquation() {
        equation = GetRandomEquation();
        equation.CreateEquation(difficulty);
        EquationControllerSnakeMath.equationRepresentation = equation.representation;
    }

    private EquationSnakeMath GetRandomEquation() {
        int max = equations.Length;
        int index = Random.Range(0, max);
        return equations[index];
    }
}
