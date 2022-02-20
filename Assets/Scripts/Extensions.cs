using UnityEngine;

namespace Mushrooms
{
    public static class VectorExtensions
    {
        public static Vector3 ToWorldPosition(this Vector2 vector, Camera camera)
        {
            return camera.ScreenToWorldPoint(
                new Vector3(vector.x, vector.y, camera.nearClipPlane)
            );
        }

        public static bool NotEmpty(this Vector2 vector)
        {
            return vector.sqrMagnitude > 0.01;
        }
    }
}
