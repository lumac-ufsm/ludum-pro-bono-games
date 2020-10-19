using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEquationSnakeMath : EquationSnakeMath {
    private int number;
    private int exponent;
    public string representation => $"{number}^{exponent}";
    public int result => (int) Mathf.Pow(number, exponent);

    public void CreateEquation(int difficulty) {
        int maxNumber = (int) Mathf.Sqrt(difficulty);
        int maxExponent = 4;
        number = Random.Range(1, maxNumber);
        exponent = Random.Range(1, maxExponent);
    }
}
