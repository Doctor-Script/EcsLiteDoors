using Leopotam.EcsLite;

namespace EcsLiteDoors
{
    sealed class InitPlayerSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerEntity = world.NewEntity();

            world.Add<PlayerInputConsumer>(playerEntity);
            world.Add<Movable>(playerEntity).Speed = 3f;
            world.Add<Stance>(playerEntity);
        }
    }
}
