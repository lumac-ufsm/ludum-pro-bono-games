using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationSnakeMath {
    public int number1;
    public int number2;
    protected EquationOperatorSnakeMath equationOperator { get; }

    protected EquationSnakeMath(int number1, int number2) {
        this.number1 = number1;
        this.number2 = number2;
    }

    public abstract int solve();    
}

public class SumEquationSnakeMath : EquationSnakeMath {
    protected override EquationOperatorSnakeMath equationOperator => EquationOperatorSnakeMath.SUM;

    public override int solve() {
        return number1 + number2;
    }
}