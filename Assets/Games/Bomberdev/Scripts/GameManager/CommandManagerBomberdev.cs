using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerBomberdev : MonoBehaviour {
	private Func.Callback _callback;

	public Func.Callback callback {
		get { return _callback; }
		set { _callback = value; }
	}

	public void Up(MovePlayerBomberdev movePlayer, int numberOfSteps) {
		movePlayer.Translate(Direction.UP, numberOfSteps, _callback);
	}

	public void Down(MovePlayerBomberdev movePlayer, int numberOfSteps) {
		movePlayer.Translate(Direction.DOWN, numberOfSteps, _callback);
	}

	public void Left(MovePlayerBomberdev movePlayer, int numberOfSteps) {
		movePlayer.Translate(Direction.LEFT, numberOfSteps, _callback);
	}

	public void Right(MovePlayerBomberdev movePlayer, int numberOfSteps) {
		movePlayer.Translate(Direction.RIGHT, numberOfSteps, _callback);
	}

	public void Bomb(Vector2 playerPosition, GameObject bombPrefab) {
		GameObject bomb = Instantiate(bombPrefab, playerPosition, Quaternion.identity);
		_callback();
	}

	public void Wait(int seconds) {
		IEnumerator Coroutine() {
			yield return new WaitForSeconds(seconds);
			_callback();
		}
		GameManagerBomberdev gameManagerBomberdev = GameManagerBomberdev.Get();
		StartCoroutine(Coroutine());
	}
}
