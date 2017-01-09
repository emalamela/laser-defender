using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    public float horizontalVelocity;

    private new Rigidbody2D rigidbody;

    private Vector3 leftBoundary;
    private Vector3 rightBoundary;

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
        Camera mainCamera = Camera.main;
        Bounds rendererBounds = GetComponent<Renderer>().bounds;
        leftBoundary = mainCamera.ViewportToWorldPoint(Vector3.zero);
        leftBoundary += new Vector3(rendererBounds.extents.x + 0.2f, 0, 0);
        rightBoundary = mainCamera.ViewportToWorldPoint(Vector3.right);
        rightBoundary -= new Vector3(rendererBounds.extents.x + 0.2f, 0, 0);
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
        return !(leftBoundary.x >= transform.position.x && movement == Movement.LEFT) &&
            !(rightBoundary.x <= transform.position.x && movement == Movement.RIGHT);
    }

}
