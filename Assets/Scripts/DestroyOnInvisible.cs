using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfCamera : MonoBehaviour {

    private const float DESTROY_DELTA_TIME = 0.5f;

    void OnBecameInvisible() {
        Destroy(this.gameObject, DESTROY_DELTA_TIME);
    }

}
