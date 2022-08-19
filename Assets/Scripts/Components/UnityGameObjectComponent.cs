using UnityEngine;

namespace EcsLiteDoors
{
    struct UnityGameObjectComponent
    {
        public GameObject GameObject;
        public Transform Transform => GameObject.transform;
    }
}
