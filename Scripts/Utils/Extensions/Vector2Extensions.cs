namespace HoodedCrow.uCore.Utils
{
    using UnityEngine;

    public static class Vector2Extensions
    {
        public static Vector2 SetX(this Vector2 vector2, float value)
        {
            vector2.x = value;
            return vector2;
        }

        public static Vector2 SetY(this Vector2 vector2, float value)
        {
            vector2.y = value;
            return vector2;
        }
    }
}
