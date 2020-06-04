using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerBomberdev {
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

    public void Bomb(GameObject player) {
        
    }
}
