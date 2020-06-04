using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBomberdev : MonoBehaviour {
    [SerializeField] private PanelFlowchartBomberdev panelFlowchart;
    private RunCommandsBomberdev runCommandsBomberdev;

    private void Update() {
        runCommandsBomberdev = GetComponent<RunCommandsBomberdev>();
        Inputs();
    }

    private void Inputs() {
        if (Input.GetKeyDown(Keys.up)) panelFlowchart.MoveOrSelect(Direction.UP);
        if (Input.GetKeyDown(Keys.down)) panelFlowchart.MoveOrSelect(Direction.DOWN);
        if (Input.GetKeyDown(Keys.left)) panelFlowchart.MoveOrSelect(Direction.LEFT);
        if (Input.GetKeyDown(Keys.right)) panelFlowchart.MoveOrSelect(Direction.RIGHT);
        if (Input.GetKeyDown(Keys.action1)) panelFlowchart.ToggleHold();
        if (Input.GetKeyDown(Keys.start)) runCommandsBomberdev.StartCommands();
    }
}
