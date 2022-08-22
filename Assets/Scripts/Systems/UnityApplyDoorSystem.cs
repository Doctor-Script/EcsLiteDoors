using Leopotam.EcsLite;

namespace EcsLiteDoors
{
    sealed class UnityApplyDoorSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<Door>().End();
            var doorsPool = world.GetPool<Door>();
            var doorViewPool = world.GetPool<UnityComponent<DoorView>>();

            foreach (var entity in filter)
            {
                var closedPercent = doorsPool.Get(entity).ClosedPercent;
                var view = doorViewPool.Get(entity).Value;
                view.SetOpenPercent(closedPercent);
            }
        }
    }
}
