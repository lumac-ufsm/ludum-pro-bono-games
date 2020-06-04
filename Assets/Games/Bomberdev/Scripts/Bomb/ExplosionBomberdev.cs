using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomberdev : MonoBehaviour {
    public float delay = 1;
    private float time = 0;

    private void Update() {
        time += Time.deltaTime;
        if (time >= delay) AutoDestroy(); 
    }

    private void AutoDestroy() {
        Destroy(gameObject);
    }
}
