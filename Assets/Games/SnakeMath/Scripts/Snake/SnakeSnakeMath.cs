using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSnakeMath : MonoBehaviour {
    [SerializeField] GameObject bodyPrefab;
    private List<GameObject> _bodyList = new List<GameObject>();
    public List<GameObject> bodyList { get { return _bodyList; } }
    public int points { get { return _bodyList.Count; } }
    public bool isStarted {
        get {
            Vector2 position = transform.position;
            foreach (GameObject body in _bodyList) {
                Vector2 bodyPosition = body.transform.position;
                if (bodyPosition != position) return true;
                position = bodyPosition;
            }
            return false;
        }
    }
    private GameAreaSnakeMath gameArea;
    
    private void Start() {
        gameArea = GameObject.Find("GameArea").GetComponent<GameAreaSnakeMath>();
        AddBody();
    }

    public void Move(Vector2 translation) {
        if (_bodyList.Count > 0) {
            for (int n = _bodyList.Count - 1; n > 0; n--) {
                _bodyList[n].transform.position = _bodyList[n - 1].transform.position;
            }
            _bodyList[0].transform.position = transform.position;
        }
        transform.Translate(translation);
    }

    public void AddBody(int num=1) {
        for (int n = 0; n < num; n++) {
            Vector2 position = new Vector2(gameArea.maxX * 2, gameArea.maxY * 2);
            GameObject body = Instantiate(bodyPrefab, position, Quaternion.identity);
            _bodyList.Add(body);
        }
    }
}
