using UnityEngine;

namespace EcsLitDoors
{
    struct UnityGameObjectComponent
    {
        public GameObject GameObject;
        public Transform Transform => GameObject.transform;
    }
}