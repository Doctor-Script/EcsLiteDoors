using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class UnityApplyTransformSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ViewWrapper<GameObject>>().Inc<Transform2D>().End();
            
            var transformPool = world.GetPool<Transform2D>();
            var gameObjectPool = world.GetPool<ViewWrapper<GameObject>>();

            foreach (var entity in filter)
            {
                ref var transform = ref transformPool.Get(entity);
                ref var gameObject = ref gameObjectPool.Get(entity);

                var unityTransform = gameObject.Value.transform;
                unityTransform.position = transform.Position.ToVector3();
                unityTransform.rotation = Quaternion.Euler(0f, transform.DirectionAngle, 0f);
            }
        }
    }
}
