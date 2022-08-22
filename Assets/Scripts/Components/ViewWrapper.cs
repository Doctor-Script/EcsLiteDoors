using UnityEngine;

namespace EcsLiteDoors
{
    struct ViewWrapper<T> where T : Object
    {
        public T Value;
    }
}
