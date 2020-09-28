using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSnakeMath : MonoBehaviour {
    [SerializeField] GameObject bodyPrefab;
    private List<GameObject> bodyList;

    private void Start() {
        bodyList = new List<GameObject>();
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

    public void addBody(int num=1) {
        for (int n = 0; n < num; n++) {
            GameObject body = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
            bodyList.Add(body);
        }
    }
}
