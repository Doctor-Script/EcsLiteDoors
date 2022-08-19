using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class UnityApplyStanceSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<UnityGameObjectComponent>().Inc<Stance>().End();

            foreach (var entity in filter)
            {
                ref var stance = ref world.GetPool<Stance>().Get(entity);
                ref var unityGameObjectComponent = ref world.GetPool<UnityGameObjectComponent>().Get(entity);

                unityGameObjectComponent.Transform.position = stance.Position.ToVector3();
                unityGameObjectComponent.Transform.rotation = Quaternion.Euler(0f, stance.DirectionDeg, 0f);
            }
        }
    }
}
