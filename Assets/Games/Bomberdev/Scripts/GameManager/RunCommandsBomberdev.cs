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
                commandManager.Up(movePlayer);
                break;
            case CommandBomberdev.DOWN:
                commandManager.Down(movePlayer);
                break;
            case CommandBomberdev.LEFT:
                commandManager.Left(movePlayer);
                break;
            case CommandBomberdev.RIGHT:
                commandManager.Right(movePlayer);
                break;
            case CommandBomberdev.BOMB:
                commandManager.Bomb(player);
                break;
        }
    }
}
