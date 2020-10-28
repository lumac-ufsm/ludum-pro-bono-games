using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBomberdev : Level {
    public LevelBomberdev(int number, bool unlocked = false) : base(number, unlocked) {
    }

    protected override string gameName => "Bomberdev";
}
