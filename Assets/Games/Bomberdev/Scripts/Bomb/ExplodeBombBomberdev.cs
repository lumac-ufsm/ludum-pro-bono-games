using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

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

    private bool CheckCollision(GameObject gameObject) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.1f);
        return colliders.Length > 1;
    }

    private void CreateExplosions(Vector2 position) {
        Vector2 unitX = new Vector2(1, 0);
        Vector2 unitY = new Vector2(0, 1);

        CreateExplosion(ExplosionTypeBomberdev.START, position);

        bool upAllowed = true;
        bool downAllowed = true;
        bool leftAllowed = true;
        bool rightAllowed = true;

        for(int n = 1; n < power; n++) {
            if (upAllowed) {
                var explosion = CreateExplosion(ExplosionTypeBomberdev.MIDDLE_VERTICAL, position + (unitY * n));
                if (CheckCollision(explosion)) upAllowed = false;
            }
            if (downAllowed) {
                var explosion = CreateExplosion(ExplosionTypeBomberdev.MIDDLE_VERTICAL, position - (unitY * n));
                if (CheckCollision(explosion)) downAllowed = false;
            }
            if (rightAllowed) {
                var explosion = CreateExplosion(ExplosionTypeBomberdev.MIDDLE_HORIZONTAL, position + (unitX * n));
                if (CheckCollision(explosion)) rightAllowed = false;
            }
            if (leftAllowed) {
                var explosion = CreateExplosion(ExplosionTypeBomberdev.MIDDLE_HORIZONTAL, position - (unitX * n));
                if (CheckCollision(explosion)) leftAllowed = false;
            }
        }

        if (upAllowed) {
            CreateExplosion(ExplosionTypeBomberdev.END_UP, position + (unitY * power));
        }
        if (downAllowed) {
            CreateExplosion(ExplosionTypeBomberdev.END_DOWN, position - (unitY * power));
        }
        if (leftAllowed) {
            CreateExplosion(ExplosionTypeBomberdev.END_LEFT, position - (unitX * power));
        }
        if (rightAllowed) {
            CreateExplosion(ExplosionTypeBomberdev.END_RIGHT, position + (unitX * power));
        }
    }

    private GameObject CreateExplosion(ExplosionTypeBomberdev type, Vector2 position) {
        GameObject Create(GameObject prefab, float rotation = 0) {
            GameObject gameObject = Instantiate(prefab, position, Quaternion.identity);
            gameObject.transform.Rotate(new Vector3(0, 0, rotation));
            return gameObject;
        }

        GameObject explosion;

        switch(type) {
            case ExplosionTypeBomberdev.START:
                explosion = Create(explosionStartPrefab);
                break;
            case ExplosionTypeBomberdev.MIDDLE_HORIZONTAL:
                explosion = Create(explosionMiddlePrefab, 90);
                break;
            case ExplosionTypeBomberdev.MIDDLE_VERTICAL:
                explosion = Create(explosionMiddlePrefab);
                break;
            case ExplosionTypeBomberdev.END_UP:
                explosion = Create(explosionEndPrefab);
                break;
            case ExplosionTypeBomberdev.END_DOWN:
                explosion = Create(explosionEndPrefab, 180);
                break;
            case ExplosionTypeBomberdev.END_LEFT:
                explosion = Create(explosionEndPrefab, 90);
                break;
            case ExplosionTypeBomberdev.END_RIGHT:
                explosion = Create(explosionEndPrefab, -90);
                break;
            default:
                explosion = Create(explosionStartPrefab);
                break;
        }

        return explosion;
    }
}
