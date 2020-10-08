using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationManagerSnakeMath : MonoBehaviour {
    private Queue<EquationSnakeMath> equationsQueue = new Queue<EquationSnakeMath>(new EquationSnakeMath[] {
        new SumEquationSnakeMath(),
        new SubtractEquationSnakeMath(),
        new MultiplicationEquationSnakeMath(),
        new DivisionEquationSnakeMath(),
        new PowerEquationSnakeMath(),
    });
    private List<EquationSnakeMath> allowedEquations = new List<EquationSnakeMath>();
    private SnakeSnakeMath snake;
    [SerializeField] private int difficulty = 1;
    [SerializeField] private int difficultyDelta = 5;
    [SerializeField] private int difficultyAddEquation = 30;
    private EquationSnakeMath currentEquation;
    private TimeManagerSnakeMath timeManager;

    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
        timeManager = GameObject.Find("GameManagerSnakeMath").GetComponent<TimeManagerSnakeMath>();
        AddAllowedEquation();
        CreateEquation();
    }

    public void OnColliderFood() {
        if (SumSnakeMath.sum == currentEquation.result) {
            IncreaseDifficulty();
            snake.AddBody();
            CreateEquation();
            SumSnakeMath.sum = 0;
            timeManager.AddTime();
        }
    }

    private void IncreaseDifficulty() {
        difficulty += difficultyDelta;
        if (difficulty > difficultyAddEquation) {
            if (AddAllowedEquation()) {
                difficulty = difficultyDelta;
            }
        }
    }

    private bool AddAllowedEquation() {
        if (equationsQueue.Count > 0) {
            EquationSnakeMath equation = equationsQueue.Dequeue();
            allowedEquations.Add(equation);
            return true;
        }
        return false;
    }

    private void CreateEquation() {
        currentEquation = GetRandomEquation();
        currentEquation.CreateEquation(difficulty);
        EquationControllerSnakeMath.equationRepresentation = currentEquation.representation;
    }

    private EquationSnakeMath GetRandomEquation() {
        int max = allowedEquations.Count;
        int index = Random.Range(0, max);
        return allowedEquations[index];
    }
}
