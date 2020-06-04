using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommandsBomberdev : MonoBehaviour {
    [SerializeField] private FlowchartBomberdev flowchartRun;
    private Queue<CommandBomberdev> commands;
    private Func.Callback callbackEndCommand;
    private MovePlayerBomberdev movePlayer;
    [SerializeField] private GameObject player;

    private void Start() {
        movePlayer = player.GetComponent<MovePlayerBomberdev>();
        callbackEndCommand = () => ExecuteNextCommand();
    }

    public void StartCommands() {
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
