using UnityEngine;

namespace EcsLiteDoors
{
    struct UnityComponent<T> where T : Component
    {
        public T Value;
    }
}