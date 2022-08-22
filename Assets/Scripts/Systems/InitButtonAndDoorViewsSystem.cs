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
            var doorsFilter = world.Filter<Door>().Inc<Stance>().End();
            foreach (var doorEntity in doorsFilter)
            {
                var position = world.Get<Stance>(doorEntity).Position;
                var color = world.Get<Colorized>(doorEntity).Color;
                var doorView = _viewsFactory.InstantiateDoor(position, color);
                world.Add<UnityComponent<DoorView>>(doorEntity).Value = doorView;
            }
        }

        private void InitButtonViews(EcsWorld world)
        {
            var buttonsFilter = world.Filter<Button>().Inc<Stance>().End();
            foreach (var buttonEntity in buttonsFilter)
            {
                var position = world.Get<Stance>(buttonEntity).Position;
                var color = world.Get<Colorized>(buttonEntity).Color;
                _viewsFactory.InstantiateButton(position, color);
            }
        }
    }
}
