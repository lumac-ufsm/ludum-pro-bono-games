using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelFlowchartBomberdev : MonoBehaviour {
    private List<GameObject> flowcharts = new List<GameObject>();
    private List<List<GameObject>> gridInstructions = new List<List<GameObject>>();
    private int indexFlowchart = 0;
    private int indexInstruction = 0;

    private GameObject instructionGameObjectSelected { get { return gridInstructions[indexFlowchart][indexInstruction]; } }
    private InstructionBomberdev instructionSelected { get { return instructionGameObjectSelected.GetComponent<InstructionBomberdev>(); } }

    private void Start() {
        foreach (Transform child in transform) {
            GameObject flowchart = child.gameObject;
            List<GameObject> instructions = flowchart.GetComponent<FlowchartBomberdev>().instructions;
            flowcharts.Add(flowchart);
            gridInstructions.Add(instructions);
        }

        instructionSelected.Select();
    }

    public void MoveOrSelect(Direction direction) {
        if (instructionSelected.hold) Move(direction);
        else MoveSelection(direction);
    }

    public void ToggleHold() {
        instructionSelected.ToggleHold();
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

        int newIndexFlowchart = indexFlowchart + indexTranslationFlowchart;
        int newIndexInstruction = indexInstruction + indexTranslationInstruction;

        for(;;) {
            if (newIndexFlowchart < 0) newIndexFlowchart = flowcharts.Count - 1;
            else if (newIndexFlowchart >= flowcharts.Count) newIndexFlowchart = 0;

            if (newIndexInstruction < 0) newIndexInstruction = gridInstructions[newIndexFlowchart].Count - 1;
            else if (newIndexInstruction >= gridInstructions[newIndexFlowchart].Count) newIndexInstruction = 0;

            if (gridInstructions[newIndexFlowchart].Count == 0) newIndexFlowchart += indexTranslationFlowchart;
            else break;
        }

        indexFlowchart = newIndexFlowchart;
        indexInstruction = newIndexInstruction;

        instructionSelected.Select();
    }

    private void Move(Direction direction) {
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

        int newIndexFlowchart = indexFlowchart + indexTranslationFlowchart;
        int newIndexInstruction = indexInstruction + indexTranslationInstruction;

        if (newIndexFlowchart < 0) newIndexFlowchart = flowcharts.Count - 1;
        else if (newIndexFlowchart >= flowcharts.Count) newIndexFlowchart = 0;
        if (newIndexInstruction < 0) newIndexInstruction = gridInstructions[indexFlowchart].Count - 1;
        else if (newIndexInstruction >= gridInstructions[indexFlowchart].Count) newIndexInstruction = 0;

        if (indexFlowchart != newIndexFlowchart) {
            if (newIndexInstruction > gridInstructions[newIndexFlowchart].Count) 
            newIndexInstruction = gridInstructions[newIndexFlowchart].Count;
        }

        instructionGameObjectSelected.transform.parent = flowcharts[newIndexFlowchart].transform;
        instructionGameObjectSelected.transform.SetSiblingIndex(newIndexInstruction + 1);

        GameObject instruction = instructionGameObjectSelected;
        gridInstructions[indexFlowchart].RemoveAt(indexInstruction);
        gridInstructions[newIndexFlowchart].Insert(newIndexInstruction, instruction);

        indexFlowchart = newIndexFlowchart;
        indexInstruction = newIndexInstruction;
        
        instructionSelected.Hold();
    }
}
