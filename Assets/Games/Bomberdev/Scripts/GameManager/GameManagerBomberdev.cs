using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBomberdev : MonoBehaviour {
    [SerializeField] private PanelFlowchartBomberdev panelFlowchart;
    [SerializeField] private GameObject panelGameOver;
    private RunCommandsBomberdev runCommandsBomberdev;

    public static GameManagerBomberdev Get() {
        return GameObject.Find("GameManagerBomberdev").GetComponent<GameManagerBomberdev>();
    }

    private void Start() {
        Time.timeScale = 1;
    }

    private void Update() {
        runCommandsBomberdev = GetComponent<RunCommandsBomberdev>();
        if (Time.timeScale > 0) Inputs();
    }

    private void Inputs() {
        if (Input.GetKeyDown(Keys.up)) panelFlowchart.MoveOrSelect(Direction.UP);
        if (Input.GetKeyDown(Keys.down)) panelFlowchart.MoveOrSelect(Direction.DOWN);
        if (Input.GetKeyDown(Keys.left)) panelFlowchart.MoveOrSelect(Direction.LEFT);
        if (Input.GetKeyDown(Keys.right)) panelFlowchart.MoveOrSelect(Direction.RIGHT);
        if (Input.GetKeyDown(Keys.action1)) panelFlowchart.ToggleHold();
        if (Input.GetKeyDown(Keys.action4)) runCommandsBomberdev.StartCommands();
    }

    public void NextLevel() {
        string name = SceneManager.GetActiveScene().name;
        int level = int.Parse(name.Replace("_BomberdevLevel", ""));
        SceneManager.LoadScene($"{level + 1}_BomberdevLevel");
    }

    public void RestartLevel() {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    public void GameOver(string deathCause) {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
        print($"Game Over\nCausa da morte: {deathCause}");
    }
}
