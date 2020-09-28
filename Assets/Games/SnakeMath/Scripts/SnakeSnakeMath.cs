using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSnakeMath : MonoBehaviour {
    [SerializeField] GameObject bodyPrefab;
    private List<GameObject> bodyList;
    public int points { get { return bodyList.Count; } }
    public bool isStart {
        get {
            Vector2 position = transform.position;
            foreach (GameObject body in bodyList) {
                Vector2 bodyPosition = body.transform.position;
                if (bodyPosition != position) return false;
                position = bodyPosition;
            }
            return true;
        }
    }
    
    private void Start() {
        bodyList = new List<GameObject>();
        AddBody(10);
    }

    public void Move(Vector2 translation) {
        if (bodyList.Count > 0) {
            for (int n = bodyList.Count - 1; n > 0; n--) {
                bodyList[n].transform.position = bodyList[n - 1].transform.position;
            }
            bodyList[0].transform.position = transform.position;
        }
        transform.Translate(translation);
    }

    public void AddBody(int num=1) {
        for (int n = 0; n < num; n++) {
            GameObject body = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
            bodyList.Add(body);
        }
    }
}
