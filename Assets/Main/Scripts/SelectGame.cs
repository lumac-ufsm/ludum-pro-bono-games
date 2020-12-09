using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour {
    [SerializeField] private GameObject[] gameSelectors;
    private float screenHeight;
    private float screenWidth;
    private int selectedGameSelector;
    [SerializeField] private float velocity;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Direction direction;
    private float maxX, minX, maxY, minY;
    [SerializeField] private float widthGameSelector;
    [SerializeField] private float marginStop;
    [SerializeField] private enum Direction {
        stop,
        left,
        center,
        right
    }

    private void Start() {
        gameSelectors = GetGameSelectors();
        screenHeight = Camera.main.orthographicSize * 2;
        screenWidth = screenHeight / Screen.height * Screen.width;

        maxX = screenWidth / 2;
        minX = -maxX;
        maxY = screenHeight / 2;
        minY = -maxY;

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        StartingPositionGameSelectors();
    }
    
    private GameObject[] GetGameSelectors() {
        List<GameObject> gameSelectorList = new List<GameObject>();
        for (int n = 0; n < transform.childCount; n++) {
            GameObject gameSelector = transform.GetChild(n).gameObject;
            gameSelectorList.Add(gameSelector);
        }
        return gameSelectorList.ToArray();
    }

    private void StartingPositionGameSelectors() {
        foreach (GameObject gameSelector in gameSelectors) {
            Vector2 position = gameSelector.transform.position;
            gameSelector.transform.position = new Vector2(maxX * 2, position.y);
        }
        Vector2 selectedGameSelectorPosition = gameSelectors[selectedGameSelector].transform.position;
        gameSelectors[selectedGameSelector].transform.position = new Vector2(0, selectedGameSelectorPosition.y);
    }

    private void Update() {
        if (Input.GetKeyDown(Keys.left)) {
            direction = Direction.left;
        }
        if (Input.GetKeyDown(Keys.right)) {
            direction = Direction.right;
        }
        if (Input.GetKeyDown(Keys.start)) OpenGameSelected();

        if (direction != Direction.stop) {
            MoveGameSelector(selectedGameSelector);
        }
    }

    private int SelectGameSelectorPrev() {
        selectedGameSelector -= 1;
        if (selectedGameSelector < 0) selectedGameSelector = gameSelectors.Length - 1;
        return selectedGameSelector;
    }

    private int SelectGameSelectorNext() {
        selectedGameSelector += 1;
        if (selectedGameSelector >= gameSelectors.Length) selectedGameSelector = 0;
        return selectedGameSelector;
    }

    private void MoveGameSelector(int numGameSelector) {
        float x = 0;
        Transform gameSelector = gameSelectors[numGameSelector].transform;

        if (direction == Direction.center) {
            Vector2 position = gameSelector.transform.position;

            if (position.x == 0) {
                direction = Direction.stop;
                return;
            }
            else if (position.x > -marginStop && position.x < marginStop) {
                position.x = 0;
                gameSelector.position = position;
            }
            else if (position.x < 0) x = velocity;
            else if (position.x > 0) x = -velocity;

            gameSelector.Translate(new Vector2(x * Time.deltaTime, 0));
        }
        else
        {
            if (direction == Direction.right) x = -velocity;
            else if (direction == Direction.left) x = velocity;

            gameSelector.Translate(new Vector2(x * Time.deltaTime, 0));
            Vector2 position = gameSelector.transform.position;

            if (position.x < minX - (widthGameSelector / 2)) {
                SelectGameSelectorPrev();
                Vector3 positionNextGameSelector = gameSelectors[selectedGameSelector].transform.transform.position;
                position.x = maxX + (widthGameSelector / 2);
                gameSelectors[selectedGameSelector].transform.transform.position = position;

                if (direction == Direction.center) direction = Direction.stop;
                else direction = Direction.center;
            }
            else if (position.x > maxX + (widthGameSelector / 2)) {
                SelectGameSelectorNext();
                Vector3 positionNextGameSelector = gameSelectors[selectedGameSelector].transform.transform.position;
                position.x = minX - (widthGameSelector / 2);
                gameSelectors[selectedGameSelector].transform.transform.position = position;

                if (direction == Direction.center) direction = Direction.stop;
                else direction = Direction.center;
            }
        }
    }

    public void OpenGameSelected() {
        string selectedGameName = gameSelectors[selectedGameSelector].name;
        GameManager.currentGame = selectedGameName;
        SceneRouter.OpenGameIntroduction(selectedGameName);
    }
}