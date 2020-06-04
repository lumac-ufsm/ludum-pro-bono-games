using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerBomberdev {
    private Func.Callback callback;
    
    public CommandManagerBomberdev(Func.Callback callback) {
        this.callback = callback;
    }

    public void Translate(MovePlayerBomberdev movePlayer, Direction direction) {
        movePlayer.Translate(direction, callback);
    }
}
