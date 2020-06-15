using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CommandManagerBomberdev : MonoBehaviour {
    private Func.Callback callback;

    public CommandManagerBomberdev(Func.Callback callback) {
        this.callback = callback;
    }

    public void Up(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.UP, callback);
    }

    public void Down(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.DOWN, callback);
    }

    public void Left(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.LEFT, callback);
    }

    public void Right(MovePlayerBomberdev movePlayer) {
        movePlayer.Translate(Direction.RIGHT, callback);
    }

    public void Bomb(Vector2 playerPosition, GameObject bombPrefab) {
        GameObject bomb = Instantiate(bombPrefab, playerPosition, Quaternion.identity);
        callback();
    }

    public void Wait(int seconds) {
        Task.Run(async () => {
            await Task.Delay(seconds * 1000);
            callback();
        });
    }
}
