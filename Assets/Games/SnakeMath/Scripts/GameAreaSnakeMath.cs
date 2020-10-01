using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaSnakeMath : MonoBehaviour {
    public int marginTop;
    public float maxX { get { return (screenWidth - 1) / 2; } }
    public float minX { get { return -maxX; } }
    public float maxY { get { return ((screenHeight - 1) / 2) - marginTop; } }
    public float minY { get { return -maxY - (marginTop * 2); } }
    public float screenHeight { 
        get {
            var (screenHeight, screenWidth) = GetScreen();
            return screenHeight;
        }
    }
    public float screenWidth { 
        get {
            var (screenHeight, screenWidth) = GetScreen();
            return screenWidth;
        }
    }

    private (float, float) GetScreen() {
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight / Screen.height * Screen.width;

        screenHeight = Mathf.Floor(screenHeight);
        screenHeight += screenHeight % 2 == 0 ? -1 : 0;
        screenWidth = Mathf.Floor(screenWidth);
        screenWidth += screenWidth % 2 == 0 ? -1 : 0;
        screenHeight -= marginTop * 2;

        return (screenHeight, screenWidth);
    }

    private void Start() {
        gameObject.transform.Translate(new Vector2(0, -marginTop));
        gameObject.transform.localScale = new Vector2(screenWidth, screenHeight);
    }
}
