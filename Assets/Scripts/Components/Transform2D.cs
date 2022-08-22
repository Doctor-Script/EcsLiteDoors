using UnityEngine;

namespace EcsLiteDoors
{
    struct Transform2D
    {
        public Vector2 Position;
        public float DirectionAngle;

        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}
