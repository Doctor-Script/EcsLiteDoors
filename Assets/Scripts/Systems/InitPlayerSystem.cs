using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class InitPlayerSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerEntity = world.NewEntity();

            world.Add<InputConsumer>(playerEntity);
            world.Add<Movable>(playerEntity).Speed = 3f;
            world.Add<Stance>(playerEntity);
            world.Add<UnityGameObjectComponent>(playerEntity).GameObject = GameObject.Find("Player");
        }
    }
}
