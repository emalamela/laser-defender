using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float health = 150.0f;

    void OnTriggerEnter2D(Collider2D collider) {
        Laser collidingLaser = collider.GetComponent<Laser>();

        if (collidingLaser == null) return;

        collidingLaser.Hit();
        health -= collidingLaser.getDamage();
        if (health <= 0) Destroy(gameObject);
    }
	
}
