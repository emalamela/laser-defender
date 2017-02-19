using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Extension;

public class PlayerShipController : MonoBehaviour {

    public float horizontalVelocity;

    public float health = 250.0f;

    public GameObject laser;
    public float laserVelocity;
    public float fireRate;

    private new Rigidbody2D rigidbody;

    private float leftBoundary;
    private float rightBoundary;

    private enum Movement {
        LEFT = -1,
        NONE = 0,
        RIGHT = 1
    }

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();

        InitializeBoundaries();
    }

    private void InitializeBoundaries() {
        Bounds rendererBounds = GetComponent<Renderer>().bounds;
        leftBoundary = Camera.main.getCameraLeftBoundary();;
        leftBoundary += rendererBounds.extents.x;
        rightBoundary = Camera.main.getCameraRightBoundary();
        rightBoundary -= rendererBounds.extents.x;
    }

    private static Movement GetMovementDirection() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return Movement.LEFT;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return Movement.RIGHT;
        } else {
            return Movement.NONE;
        }
    }

    void FixedUpdate() {
        HandleMovement();
        HandleFiring();
    }

    private void HandleMovement() {
        Movement movement = GetMovementDirection();

        if (!CanMove(movement)) {
            rigidbody.velocity = Vector2.zero;
            return;
        }

        rigidbody.velocity = 
            new Vector2(((int) movement) * horizontalVelocity, rigidbody.velocity.y);
    }

    private bool CanMove(Movement movement) {
        return !(leftBoundary >= transform.position.x && movement == Movement.LEFT) &&
               !(rightBoundary <= transform.position.x && movement == Movement.RIGHT);
    }

    void HandleFiring() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.00001f, fireRate);
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }
    }

    private void Fire() {
        GameObject laserClone = Instantiate(laser, transform.position, Quaternion.identity);
        laserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, laserVelocity);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Laser collidingLaser = collider.GetComponent<Laser>();

        if (collidingLaser == null) return;

        collidingLaser.Hit();
        health -= collidingLaser.getDamage();
        if (health <= 0) Destroy(gameObject);
    }

}
