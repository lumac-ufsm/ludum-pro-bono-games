using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerSnakeMath : MonoBehaviour {
    [SerializeField] private float _time;
    private float timeCounter = 0;
    public int time { get { return (int) _time; } }

    private void Update() {
        _time -= Time.deltaTime;
        if (_time < 0) _time = 0;
        UpdateTimeUI();
    }

    private void UpdateTimeUI() {
        TimeControllerSnakeMath.time = (int) _time;
    }

    public void AddTime(int time) {
        this._time += time;
    }
}
