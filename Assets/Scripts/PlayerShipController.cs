using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    public float horizontalVelocity;

    private new Rigidbody2D rigidbody;

    private enum Movement {
        LEFT = -1,
        NONE = 0,
        RIGHT = 1
    }

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
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
        rigidbody.velocity = 
            new Vector2(((int)GetMovementDirection()) * horizontalVelocity,
                        rigidbody.velocity.y);
    }

}
