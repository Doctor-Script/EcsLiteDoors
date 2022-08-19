using UnityEngine;

namespace EcsLiteDoors
{
    struct Stance
    {
        public Vector2 Position;
        public float DirectionDeg;

        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}
