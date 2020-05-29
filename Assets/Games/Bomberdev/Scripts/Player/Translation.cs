
using UnityEngine;

public class Translation {
    public Direction direction;
    public Vector2 position;

    public Translation(Direction direction, Vector2 position) {
        this.direction = direction;
        this.position = position;
    }
}