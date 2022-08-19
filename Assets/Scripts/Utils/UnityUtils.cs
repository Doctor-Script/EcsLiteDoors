using UnityEngine;

namespace EcsLiteDoors
{
    public static class UnityUtils
    {
        public static float DeltaTime => Time.deltaTime;

        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }
        
        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0f, vector2.y);
        }
    }
}
