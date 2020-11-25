using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovePacmaze : MonoBehaviour {
    [SerializeField] private GhostMoveDeltaPacmaze[] ghostMoveDeltaList;
    [SerializeField] private float blockSize = 0.4f;
    [SerializeField] private float speedModule = 0.005f;
    private int currentIndexGhostMoveDelta = 0;
    private Vector2 nextPosition;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        UpdateNextPosition();
    }

    private void Update() {
        (int deltaX, int deltaY) = Delta();
        transform.Translate(new Vector2(deltaX*speedModule, deltaY*speedModule));
        
        if (FinishStep(deltaX, deltaY)) {
            transform.position = new Vector2(nextPosition.x, nextPosition.y);
            currentIndexGhostMoveDelta += 1;
            if (currentIndexGhostMoveDelta >= ghostMoveDeltaList.Length) {
                currentIndexGhostMoveDelta = 0;
            }
            UpdateNextPosition();
        }
    }

    private bool FinishStep(int deltaX, int deltaY) {
        float x1 = transform.position.x;
        float y1 = transform.position.y;
        float x2 = nextPosition.x;
        float y2 = nextPosition.y;
        if (deltaX > 0 && x1 > x2) return true;
        if (deltaX < 0 && x1 < x2) return true;
        if (deltaY > 0 && y1 > y2) return true;
        if (deltaY < 0 && y1 < y2) return true;
        return false;
    }

    private void UpdateNextPosition() {
        (int deltaX, int deltaY) = Delta();
        Vector2 position = transform.position;
        nextPosition = new Vector2(position.x + (blockSize * deltaX), position.y + (blockSize * deltaY));
    }

    public (int, int) Delta() {
        GhostMoveDeltaPacmaze ghostMoveDelta = ghostMoveDeltaList[currentIndexGhostMoveDelta];
        int deltaX = ghostMoveDelta.axes == GhostMoveAxesPacmaze.X ? ghostMoveDelta.delta : 0;
        int deltaY = ghostMoveDelta.axes == GhostMoveAxesPacmaze.Y ? ghostMoveDelta.delta : 0;
        animator.SetInteger("deltaX", deltaX);
        animator.SetInteger("deltaY", deltaY);
        return (deltaX, deltaY);
    }
}
