using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Extension;

public class EnemyFormation : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 4.5f;
    public float speed = 1.0f;

    public float enemySpawnDelay = 0.5f;

    private float leftBoundary;
    private float rightBoundary;

    private bool movingRight;

	void Start () {
        leftBoundary = Camera.main.getCameraLeftBoundary();
        rightBoundary = Camera.main.getCameraRightBoundary();
        movingRight = true;

        SpawnEnemiesUntilFull();
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
            SpawnEnemiesUntilFull();
        }
    }

    private void SpawnEnemiesUntilFull() {
        Transform emptySpawnPosition = NextEmptySpawnPosition();

        if (emptySpawnPosition == null) return;

        SpawnEnemyAt(emptySpawnPosition);
        Invoke("SpawnEnemiesUntilFull", enemySpawnDelay);
    }

    private void SpawnEnemyAt(Transform spawnPosition) {
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = spawnPosition;
    }

    private Transform NextEmptySpawnPosition() {
        foreach (Transform spawnPosition in transform) {
            if (spawnPosition.childCount == 0) return spawnPosition;
        }

        return null;
    }

    private void UpdateDirectionIfNeeded() {
        if ((transform.position.x - width) < leftBoundary) movingRight = true;
        else if ((transform.position.x + width > rightBoundary)) movingRight = false;
    }

}
