using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	void Start () {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.parent = transform;
	}

}
