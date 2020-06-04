using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBomberdev : MonoBehaviour {
    [SerializeField] private PanelFlowchartBomberdev panelFlowchart;
    [SerializeField] private FlowchartBomberdev flowchartRun;
    [SerializeField] private GameObject player;
    private MovePlayerBomberdev movePlayer;

    private void Start() {
        movePlayer = player.GetComponent<MovePlayerBomberdev>();
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
        if (Input.GetKeyDown(Keys.start)) Run();
    }

    private List<CommandBomberdev> GetCommands() {
        List<CommandBomberdev> commands = new List<CommandBomberdev>();
        foreach(GameObject instructionGameObject in flowchartRun.instructions) {
            InstructionBomberdev instruction = instructionGameObject.GetComponent<InstructionBomberdev>();
            commands.Add(instruction.command);
        }
        return commands;
    }

    private void Run() {
        List<CommandBomberdev> commands = GetCommands();

        foreach(CommandBomberdev command in commands) {
            switch(command) {
                case CommandBomberdev.UP:
                    movePlayer.Translate(Direction.UP);
                    break;
                case CommandBomberdev.DOWN:
                    movePlayer.Translate(Direction.DOWN);
                    break;
                case CommandBomberdev.LEFT:
                    movePlayer.Translate(Direction.LEFT);
                    break;
                case CommandBomberdev.RIGHT:
                    movePlayer.Translate(Direction.RIGHT);
                    break;
            }
        }
    }
}
