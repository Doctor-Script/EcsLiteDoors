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
            world.Add<Movable>(playerEntity).Speed = Config.PLAYER_SPEED;
            world.Add<Transform2D>(playerEntity);
            world.Add<CircleCollider>(playerEntity).Radius = 0.5f;
            world.Add<Name>(playerEntity).Text = "Player";
        }
    }
}
