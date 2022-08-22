using Leopotam.EcsLite;

namespace EcsLiteDoors
{
    sealed class InitButtonAndDoorViewsSystem : IEcsInitSystem
    {
        private readonly ViewsFactory _viewsFactory;

        public InitButtonAndDoorViewsSystem(ViewsFactory viewsFactory) {
            _viewsFactory = viewsFactory;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            InitDoorViews(world);
            InitButtonViews(world);
        }

        private void InitDoorViews(EcsWorld world)
        {
            var doorsFilter = world.Filter<Door>().Inc<Transform2D>().End();
            
            var transformPool = world.GetPool<Transform2D>();
            var colorizedPool = world.GetPool<Colorized>();
            var doorViewPool = world.GetPool<ViewWrapper<DoorView>>();
            
            foreach (var doorEntity in doorsFilter)
            {
                var position = transformPool.Get(doorEntity).Position;
                var color = colorizedPool.Get(doorEntity).Color;
                var doorView = _viewsFactory.InstantiateDoor(position, color);
                doorViewPool.Add(doorEntity).Value = doorView;
            }
        }

        private void InitButtonViews(EcsWorld world)
        {
            var buttonsFilter = world.Filter<Button>().Inc<Transform2D>().End();
            
            var transformPool = world.GetPool<Transform2D>();
            var colorizedPool = world.GetPool<Colorized>();
            
            foreach (var buttonEntity in buttonsFilter)
            {
                var position = transformPool.Get(buttonEntity).Position;
                var color = colorizedPool.Get(buttonEntity).Color;
                _viewsFactory.InstantiateButton(position, color);
            }
        }
    }
}
