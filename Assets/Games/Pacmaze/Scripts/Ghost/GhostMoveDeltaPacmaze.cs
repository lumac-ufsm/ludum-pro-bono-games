using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GhostMoveAxesPacmaze {
    X,
    Y
}

[Serializable]
public class GhostMoveDeltaPacmaze {
    public int delta;
    public GhostMoveAxesPacmaze axes;

    public GhostMoveDeltaPacmaze(int delta, GhostMoveAxesPacmaze axes) {
        this.delta = delta;
        this.axes = axes;
    }
}