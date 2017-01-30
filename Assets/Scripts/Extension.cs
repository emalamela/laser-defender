using System;

using UnityEngine;

namespace Extension {

    public static class CameraExtension {

        public static float getCameraLeftBoundary(this Camera camera) {
            return camera.ViewportToWorldPoint(Vector3.zero).x;
        }

        public static float getCameraRightBoundary(this Camera camera) {
            return camera.ViewportToWorldPoint(Vector3.right).x;
        }

    }
}

