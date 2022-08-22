using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class InitPlayerViewSystem : IEcsInitSystem
    {
        private readonly ViewsFactory _viewsFactory;

        public InitPlayerViewSystem(ViewsFactory viewsFactory)
        {
            _viewsFactory = viewsFactory;
        }
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerInputConsumer>().Inc<Stance>().End();
            
            var stancePool = world.GetPool<Stance>();
            var playerGameObjectPool = world.GetPool<ViewWrapper<GameObject>>();
            
            foreach (var entity in filter)
            {
                var position = stancePool.Get(entity).Position;
                playerGameObjectPool.Add(entity).Value = _viewsFactory.InstantiatePlayer(position);
            }
        }
    }
}
