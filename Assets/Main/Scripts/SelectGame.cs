using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour {
    [SerializeField] private GameObject[] cards;
    private float screenHeight;
    private float screenWidth;
    private int selectedCard;
    [SerializeField] private float velocity;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Direction direction;
    private float maxX, minX, maxY, minY;
    [SerializeField] private float widthCard;
    [SerializeField] private float marginStop;
    [SerializeField] private enum Direction {
        stop,
        left,
        center,
        right
    }

    private void Start() {
        screenHeight = Camera.main.orthographicSize * 2;
        screenWidth = screenHeight / Screen.height * Screen.width;

        maxX = screenWidth / 2;
        minX = -maxX;
        maxY = screenHeight / 2;
        minY = -maxY;

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        StartingPositionCards();
    }

    private void StartingPositionCards() {
        foreach (GameObject card in cards) {
            Vector2 position = card.transform.position;
            card.transform.position = new Vector2(maxX * 2, position.y);
        }
        Vector2 selectedCardPosition = cards[selectedCard].transform.position;
        cards[selectedCard].transform.position = new Vector2(0, selectedCardPosition.y);
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
            MoveCard(selectedCard);
        }
    }

    private int SelectCardPrev() {
        selectedCard -= 1;
        if (selectedCard < 0) selectedCard = cards.Length - 1;
        return selectedCard;
    }

    private int SelectCardNext() {
        selectedCard += 1;
        if (selectedCard >= cards.Length) selectedCard = 0;
        return selectedCard;
    }

    private void MoveCard(int numCard) {
        float x = 0;
        Transform card = cards[numCard].transform;

        if (direction == Direction.center) {
            Vector2 position = card.transform.position;

            if (position.x == 0) {
                direction = Direction.stop;
                return;
            }
            else if (position.x > -marginStop && position.x < marginStop) {
                position.x = 0;
                card.position = position;
            }
            else if (position.x < 0) x = velocity;
            else if (position.x > 0) x = -velocity;

            card.Translate(new Vector2(x * Time.deltaTime, 0));
        }
        else
        {
            if (direction == Direction.right) x = -velocity;
            else if (direction == Direction.left) x = velocity;

            card.Translate(new Vector2(x * Time.deltaTime, 0));
            Vector2 position = card.transform.position;

            if (position.x < minX - (widthCard / 2)) {
                SelectCardPrev();
                Vector3 positionNextCard = cards[selectedCard].transform.transform.position;
                position.x = maxX + (widthCard / 2);
                cards[selectedCard].transform.transform.position = position;

                if (direction == Direction.center) direction = Direction.stop;
                else direction = Direction.center;
            }
            else if (position.x > maxX + (widthCard / 2)) {
                SelectCardNext();
                Vector3 positionNextCard = cards[selectedCard].transform.transform.position;
                position.x = minX - (widthCard / 2);
                cards[selectedCard].transform.transform.position = position;

                if (direction == Direction.center) direction = Direction.stop;
                else direction = Direction.center;
            }
        }
    }

    public void OpenGameSelected() {
        string selectedGameName = cards[selectedCard].name;
        GameManager.currentGame = selectedGameName;
        SceneRouter.OpenGameIntroduction(selectedGameName);
    }
}