using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float gizmoBoxPadding = 2.0f;

	void Start () {
        SpawnEnemies();
	}

    void SpawnEnemies() {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(
            transform.position,
            CalculateChildrenBounds().size + new Vector3(gizmoBoxPadding, gizmoBoxPadding, 0));
    }

    private Bounds CalculateChildrenBounds() {
        Bounds childBounds = new Bounds(transform.position, Vector3.zero);

        foreach (Transform child in transform) {
            if (!childBounds.Contains(child.position)) {
                childBounds.Expand(Abs(child.position));
            }
        }

        return childBounds;
    }

    private Vector3 Abs(Vector3 target) {
        return new Vector3(
            Mathf.Abs(target.x),
            Mathf.Abs(target.y),
            Mathf.Abs(target.z));
    }

}
