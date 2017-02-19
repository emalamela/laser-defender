using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    public float health = 150.0f;

    public GameObject laser;
    public float fireRateSeconds = 0.5f;
    public float laserVelocity = 5.0f;

    void Update() {
        float fireProbability = fireRateSeconds * Time.deltaTime;

        if (Random.value < fireProbability) Fire();
    }

    private void Fire() {
        GameObject laserClone = Instantiate(laser, transform.position, Quaternion.identity);
        laserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -laserVelocity);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Laser collidingLaser = collider.GetComponent<Laser>();

        if (collidingLaser == null) return;

        collidingLaser.Hit();
        health -= collidingLaser.getDamage();
        if (health <= 0) Destroy(gameObject);
    }
	
}
