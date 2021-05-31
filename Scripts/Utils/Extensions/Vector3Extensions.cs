namespace HoodedCrow.uCore.Utils
{
    using UnityEngine;

    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 vector3, float value)
        {
            vector3.x = value;
            return vector3;
        }

        public static Vector3 SetY(this Vector3 vector3, float value)
        {
            vector3.y = value;
            return vector3;
        }

        public static Vector3 SetZ(this Vector3 vector3, float value)
        {
            vector3.z = value;
            return vector3;
        }
    }
}
