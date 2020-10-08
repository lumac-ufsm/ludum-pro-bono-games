using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrtEquationSnakeMath : EquationSnakeMath {
    private int number;
    public string representation => $"√{number}";
    public int result => (int) Mathf.Sqrt(number);

    public void CreateEquation(int difficulty) {
        int randomNumber = Random.Range(1, difficulty / 5);
        number = (int) Mathf.Pow(randomNumber, 2);
    }
}
