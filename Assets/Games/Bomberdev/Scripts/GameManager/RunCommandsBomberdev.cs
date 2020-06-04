using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommandsBomberdev : MonoBehaviour {
    [SerializeField] private FlowchartBomberdev flowchartRun;
    private Queue<CommandBomberdev> commands;
    private CommandManagerBomberdev commandManager;
    private Func.Callback callbackEndCommand;
    private MovePlayerBomberdev movePlayer;
    [SerializeField] private GameObject player;

    private void Start() {
        movePlayer = player.GetComponent<MovePlayerBomberdev>();
        callbackEndCommand = () => ExecuteNextCommand();
        commandManager = new CommandManagerBomberdev(callbackEndCommand);
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
                commandManager.Translate(movePlayer, Direction.UP);
                break;
            case CommandBomberdev.DOWN:
                commandManager.Translate(movePlayer, Direction.DOWN);
                break;
            case CommandBomberdev.LEFT:
                commandManager.Translate(movePlayer, Direction.LEFT);
                break;
            case CommandBomberdev.RIGHT:
                commandManager.Translate(movePlayer, Direction.RIGHT);
                break;
        }
    }
}
