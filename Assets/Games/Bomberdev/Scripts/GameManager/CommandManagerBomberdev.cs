using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerBomberdev : MonoBehaviour {
    private Func.Callback _callback;

    public Func.Callback callback {
        get { return _callback; }
        set { _callback = value; }
    }

    public void Up(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.UP, _callback);
    }

    public void Down(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.DOWN, _callback);
    }

    public void Left(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.LEFT, _callback);
    }

    public void Right(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.RIGHT, _callback);
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
        GameManagerBomberdev gameManagerBomberdev = 
            GameObject.Find("GameManager").GetComponent<GameManagerBomberdev>();
        gameManagerBomberdev.StartCoroutineGameManager(Coroutine());
    }
}
