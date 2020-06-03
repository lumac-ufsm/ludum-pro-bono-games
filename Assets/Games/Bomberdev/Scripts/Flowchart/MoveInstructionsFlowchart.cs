using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstructionsFlowchart : MonoBehaviour {
    private List<GameObject> flowcharts = new List<GameObject>();
    private List<List<GameObject>> gridInstructions = new List<List<GameObject>>();
    private int indexFlowchart = 0;
    private int indexInstruction = 0;

    private Instruction instructionSelected { get { return gridInstructions[indexFlowchart][indexInstruction].GetComponent<Instruction>(); } }

    private void Start() {
        foreach (Transform child in transform) {
            GameObject flowchart = child.gameObject;
            List<GameObject> instructions = flowchart.GetComponent<Flowchart>().instructions;
            flowcharts.Add(flowchart);
            gridInstructions.Add(instructions);
        }

        instructionSelected.Select();
    }

    private void Update() {
        InputMoveSelection();
    }

    private void InputMoveSelection() {
        if (Input.GetKeyDown(Keys.up)) MoveSelection(Direction.UP);
        if (Input.GetKeyDown(Keys.down)) MoveSelection(Direction.DOWN);
        if (Input.GetKeyDown(Keys.left)) MoveSelection(Direction.LEFT);
        if (Input.GetKeyDown(Keys.right)) MoveSelection(Direction.RIGHT);
    }

    private void MoveSelection(Direction direction) {
        int indexTranslationFlowchart = 0;
        int indexTranslationInstruction = 0;

        switch(direction) {
            case Direction.UP:
                indexTranslationInstruction = -1;
                break;
            case Direction.DOWN:
                indexTranslationInstruction = 1;
                break;
            case Direction.LEFT:
                indexTranslationFlowchart = -1;
                break;
            case Direction.RIGHT:
                indexTranslationFlowchart = 1;
                break;
        }

        instructionSelected.Unselect();

        indexFlowchart += indexTranslationFlowchart;
        indexInstruction += indexTranslationInstruction;

        instructionSelected.Select();
    }
}
