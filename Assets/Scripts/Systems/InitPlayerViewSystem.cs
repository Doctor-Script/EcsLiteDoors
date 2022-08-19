using Leopotam.EcsLite;

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
            foreach (var entity in filter)
            {
                var position = world.Get<Stance>(entity).Position;
                world.Add<UnityGameObjectComponent>(entity).GameObject = _viewsFactory.InstantiatePlayer(position);
            }
        }
    }
}