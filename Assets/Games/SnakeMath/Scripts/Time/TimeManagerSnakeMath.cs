using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerSnakeMath : MonoBehaviour {
    [SerializeField] private float _time = 60;
    private float timeCounter = 0;
    public int time { get { return (int) Mathf.Ceil(_time); } }
    private SnakeSnakeMath snake;

    private void Start() {
        snake = GameObject.Find("Snake").GetComponent<SnakeSnakeMath>();
    }

    private void Update() {
        if (snake.isStarted) _time -= Time.deltaTime;
        if (_time < 0) _time = 0;
        UpdateTimeUI();
    }

    private void UpdateTimeUI() {
        TimeControllerSnakeMath.time = time;
    }

    public void AddTime(int time=20) {
        this._time += time;
    }
}
