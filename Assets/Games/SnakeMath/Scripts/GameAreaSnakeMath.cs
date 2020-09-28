using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaSnakeMath : MonoBehaviour {
    private float screenHeight;
    private float screenWidth;
    public int marginTop;
    private float _maxX, _minX, _maxY, _minY;

    public float maxX { get { return _maxX; } }
    public float minX { get { return _minX; } }
    public float maxY { get { return _maxY; } }
    public float minY { get { return _minY; } }

    private void Start() {
        screenHeight = Camera.main.orthographicSize * 2;
        screenWidth = screenHeight / Screen.height * Screen.width;

        screenHeight = Mathf.Floor(screenHeight);
        screenHeight += screenHeight % 2 == 0 ? -1 : 0;
        screenWidth = Mathf.Floor(screenWidth);
        screenWidth += screenWidth % 2 == 0 ? -1 : 0;
        screenHeight -= marginTop * 2;

        gameObject.transform.Translate(new Vector2(0, -marginTop));

        _maxX = (screenWidth - 1) / 2;
        _minX = -_maxX;
        _maxY = ((screenHeight - 1) / 2);
        _minY = -_maxY;
        _maxY -= marginTop;
        _minY -= marginTop;

        gameObject.transform.localScale = new Vector2(screenWidth, screenHeight);
    }
}
