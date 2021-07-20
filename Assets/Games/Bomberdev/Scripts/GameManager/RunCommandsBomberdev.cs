using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommandsBomberdev : MonoBehaviour {
	private Queue<(CommandBomberdev, GameObject)> commands;
	private CommandManagerBomberdev commandManager;
	private Func.Callback callbackEndCommand;
	private MovePlayerBomberdev movePlayer;
	[SerializeField] private GameObject bombPrefab;
	[SerializeField] private FlowchartBomberdev _flowchartRun;
	public FlowchartBomberdev flowchartRun {
		get { return _flowchartRun; }
	}
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
		foreach (GameObject instructionGameObject in _flowchartRun.instructions) {
			InstructionBomberdev instruction = instructionGameObject.GetComponent<InstructionBomberdev>();
			commands.Enqueue((instruction.command, instructionGameObject));
		}
	}

	private void ExecuteNextCommand() {
		if (commands.Count > 0) {
			var (command, gameObject) = commands.Dequeue();
			ExecuteCommand(command, gameObject);
		}
	}

	private void ExecuteCommand(CommandBomberdev command, GameObject instructionGameObject) {
		int numberOfSteps = instructionGameObject.GetComponent<MoveInstructionBomberdev>()?.numberOfSteps ?? 1;

		switch (command) {
			case CommandBomberdev.UP:
				commandManager.Up(movePlayer, numberOfSteps);
				break;
			case CommandBomberdev.DOWN:
				commandManager.Down(movePlayer, numberOfSteps);
				break;
			case CommandBomberdev.LEFT:
				commandManager.Left(movePlayer, numberOfSteps);
				break;
			case CommandBomberdev.RIGHT:
				commandManager.Right(movePlayer, numberOfSteps);
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
