using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLitDoors
{
    sealed class InitPlayerSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerEntity = world.NewEntity();
            
            world.GetPool<InputConsumer>().Add(playerEntity);
            world.GetPool<Movable>().Add(playerEntity).Speed = 3f;
            world.GetPool<Stance>().Add(playerEntity);
            world.GetPool<UnityGameObjectComponent>().Add(playerEntity).GameObject = GameObject.Find("Player");
        }
    }
}
