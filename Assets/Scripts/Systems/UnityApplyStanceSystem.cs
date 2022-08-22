using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class UnityApplyStanceSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ViewWrapper<GameObject>>().Inc<Stance>().End();
            
            var stancePool = world.GetPool<Stance>();
            var gameObjectPool = world.GetPool<ViewWrapper<GameObject>>();

            foreach (var entity in filter)
            {
                ref var stance = ref stancePool.Get(entity);
                ref var gameObject = ref gameObjectPool.Get(entity);

                var unityTransform = gameObject.Value.transform;
                unityTransform.position = stance.Position.ToVector3();
                unityTransform.rotation = Quaternion.Euler(0f, stance.DirectionDeg, 0f);
            }
        }
    }
}
