using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBombBomberdev : MonoBehaviour {
    public float delay = 3;
    public int power = 1;
    private float time = 0;

    private void Update() {
        time += Time.deltaTime;
        if (time >= delay) Explode(); 
    }

    private void Explode() {
        Destroy(gameObject);
    }
}
