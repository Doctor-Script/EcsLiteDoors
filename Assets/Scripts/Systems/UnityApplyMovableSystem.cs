using Leopotam.EcsLite;

namespace EcsLitDoors
{
    sealed class UnityApplyMovableSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<UnityGameObjectComponent>().Inc<Movable>().End();

            foreach (var entity in filter)
            {
                ref var movable = ref world.GetPool<Movable>().Get(entity);
                ref var unityGameObjectComponent = ref world.GetPool<UnityGameObjectComponent>().Get(entity);

                unityGameObjectComponent.Transform.position = movable.Position;
            }
        }
    }
}
