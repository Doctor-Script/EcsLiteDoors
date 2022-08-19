using UnityEngine;

namespace EcsLiteDoors
{
    struct Stance
    {
        public Vector3 Position;
        public float Angle;

        public void SetPosition(float x, float y)
        {
            Position = new Vector3(x, 0f, y);
        }
    }
}
