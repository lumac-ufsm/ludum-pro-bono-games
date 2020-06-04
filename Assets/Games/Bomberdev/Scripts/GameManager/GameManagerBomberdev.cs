using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBomberdev : MonoBehaviour {
    [SerializeField] private PanelFlowchartBomberdev panelFlowchart;
    [SerializeField] private FlowchartBomberdev flowchartRun;
    [SerializeField] private GameObject player;
    private MovePlayerBomberdev movePlayer;
    private Func.Callback callbackEndCommand;
    private Queue<CommandBomberdev> commands;

    private void Start() {
        movePlayer = player.GetComponent<MovePlayerBomberdev>();
        callbackEndCommand = () => ExecuteNextCommand();
    }

    private void Update() {
        Inputs();
    }

    private void Inputs() {
        if (Input.GetKeyDown(Keys.up)) panelFlowchart.MoveOrSelect(Direction.UP);
        if (Input.GetKeyDown(Keys.down)) panelFlowchart.MoveOrSelect(Direction.DOWN);
        if (Input.GetKeyDown(Keys.left)) panelFlowchart.MoveOrSelect(Direction.LEFT);
        if (Input.GetKeyDown(Keys.right)) panelFlowchart.MoveOrSelect(Direction.RIGHT);
        if (Input.GetKeyDown(Keys.action1)) panelFlowchart.ToggleHold();
        if (Input.GetKeyDown(Keys.start)) StartCommands();
    }

    private void StartCommands() {
        UpdateCommands();
        ExecuteNextCommand();
    }

    private void UpdateCommands() {
        commands = new Queue<CommandBomberdev>();
        foreach(GameObject instructionGameObject in flowchartRun.instructions) {
            InstructionBomberdev instruction = instructionGameObject.GetComponent<InstructionBomberdev>();
            commands.Enqueue(instruction.command);
        }
    }

    private void ExecuteNextCommand() {
        if (commands.Count > 0) ExecuteCommand(commands.Dequeue());
    }

    private void ExecuteCommand(CommandBomberdev command) {
        switch(command) {
            case CommandBomberdev.UP:
                movePlayer.Translate(Direction.UP, callbackEndCommand);
                break;
            case CommandBomberdev.DOWN:
                movePlayer.Translate(Direction.DOWN, callbackEndCommand);
                break;
            case CommandBomberdev.LEFT:
                movePlayer.Translate(Direction.LEFT, callbackEndCommand);
                break;
            case CommandBomberdev.RIGHT:
                movePlayer.Translate(Direction.RIGHT, callbackEndCommand);
                break;
        }
    }
}
