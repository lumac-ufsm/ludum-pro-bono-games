using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    public int number;
    private bool _unlocked = false;
    protected abstract string gameName { get; }
    public bool unlocked { get { return _unlocked; } }

    public Level(int number, bool unlocked=false) {
        this.number = number;
        this._unlocked = unlocked;
    }

    public void Lock() {
        _unlocked = false;
    }

    public void Unlock() {
        _unlocked = true;
    }

    public void StartNext() {
        SceneRouter.OpenGameLevel(gameName, number);
    }

    public void Start() {
        SceneRouter.OpenGameLevel(gameName, number);
    }
}
