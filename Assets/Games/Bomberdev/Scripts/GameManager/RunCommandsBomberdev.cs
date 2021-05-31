using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommandsBomberdev : MonoBehaviour {
    private Queue<(CommandBomberdev, GameObject)> commands;
    private CommandManagerBomberdev commandManager;
    private Func.Callback callbackEndCommand;
    private MovePlayerBomberdev movePlayer;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private FlowchartBomberdev flowchartRun;
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
        movePlayer = player.GetComponent<MovePlayerBomberdev>();
        callbackEndCommand = () => ExecuteNextCommand();
        commandManager = GetComponent<CommandManagerBomberdev>();
        commandManager.callback = callbackEndCommand;
    }

    public void StartCommands() {
        UpdateCommands();
        ExecuteNextCommand();
    }

    private void UpdateCommands() {
        commands = new Queue<(CommandBomberdev, GameObject)>();
        foreach(GameObject instructionGameObject in flowchartRun.instructions) {
            InstructionBomberdev instruction = instructionGameObject.GetComponent<InstructionBomberdev>();
            commands.Enqueue((instruction.command, instructionGameObject));
        }
    }

    private void ExecuteNextCommand() {
        var (command, gameObject) = commands.Dequeue();
        if (commands.Count > 0) ExecuteCommand(command, gameObject);
    }

    private void ExecuteCommand(CommandBomberdev command, GameObject instructionGameObject) {
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
                commandManager.Bomb(player.transform.position, bombPrefab);
                break;
            case CommandBomberdev.WAIT:
                commandManager.Wait(3);
                break;
        }
    }
}
