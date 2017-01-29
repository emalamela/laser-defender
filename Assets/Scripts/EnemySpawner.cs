using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	void Start () {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++) {
            Transform childTransform = transform.GetChild(i);
            GameObject enemy = Instantiate(enemyPrefab, childTransform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = childTransform;
        }
	}

}
