using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Extension;

public class EnemyFormation : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 4.5f;
    public float speed = 1.0f;

    private float leftBoundary;
    private float rightBoundary;

    private bool movingRight;

	void Start () {
        leftBoundary = Camera.main.getCameraLeftBoundary();
        rightBoundary = Camera.main.getCameraRightBoundary();
        movingRight = true;

        SpawnEnemies();
	}

    void SpawnEnemies() {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private bool AllEnemiesDestroyed() {
        foreach (Transform spawnPosition in transform) {
            if (spawnPosition.childCount > 0) return false;
        }

        return true;
    }

    private void ChangeDirection() {
        movingRight = !movingRight;
    }

    void Update() {
        transform.position += 
            (movingRight ? Vector3.right : Vector3.left) * speed * Time.deltaTime;

        UpdateDirectionIfNeeded();

        if (AllEnemiesDestroyed()) {
            SpawnEnemies();
        }
    }

    private void UpdateDirectionIfNeeded() {
        if ((transform.position.x - width) < leftBoundary) movingRight = true;
        else if ((transform.position.x + width > rightBoundary)) movingRight = false;
    }

}
