using Leopotam.EcsLite;

namespace EcsLitDoors
{
    sealed class MoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MoveCommand>().Inc<Movable>().End();
            var moveCommandPool = world.GetPool<MoveCommand>();

            foreach (var entity in filter)
            {
                ref var movable = ref world.GetPool<Movable>().Get(entity);
                ref var moveCommand = ref moveCommandPool.Get(entity);

                movable.Position = moveCommand.Target;
                moveCommandPool.Del(entity);
            }
        }
    }
}
