using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBombBomberdev : MonoBehaviour {
    [SerializeField] private GameObject explosionStartPrefab;
    [SerializeField] private GameObject explosionMiddlePrefab;
    [SerializeField] private GameObject explosionEndPrefab;
    [SerializeField] private float delay = 3;
    [SerializeField] private int power = 1;
    private float time = 0;

    private void Update() {
        time += Time.deltaTime;
        if (time >= delay) Explode(); 
    }

    private void Explode() {
        Vector2 position = gameObject.transform.position;
        Destroy(gameObject);
        CreateExplosions(position);
    }

    private void CreateExplosions(Vector2 position) {

    }
}
