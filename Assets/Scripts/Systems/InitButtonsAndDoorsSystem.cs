using Leopotam.EcsLite;

namespace EcsLiteDoors
{
    sealed class InitButtonsAndDoorsSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            // Probably we would have some config on the real server.
            AddDoor(world, 7f, 7f, 5f, 5f, 0xFF0000);
            AddDoor(world, -7f, 7f, -5f, 5f, 0x00FF00);
        }

        private void AddDoor(EcsWorld world, float doorX, float doorY, float buttonX, float buttonY, uint color)
        {
            var doorEntity = world.NewEntity();
            world.Add<Transform2D>(doorEntity).SetPosition(doorX, doorY);
            world.Add<Door>(doorEntity).ClosedPercent = 1f;
            world.Add<Colorized>(doorEntity).Color = color;
            world.Add<Name>(doorEntity).Text = $"Door 0x{color:X6}";
            
            var buttonEntity = world.NewEntity();
            world.Add<Transform2D>(buttonEntity).SetPosition(buttonX, buttonY);
            world.Add<CircleCollider>(buttonEntity).Radius = 0.5f;
            world.Add<Button>(buttonEntity).PackedDoorEntity = world.PackEntity(doorEntity);
            world.Add<Colorized>(buttonEntity).Color = color;
            world.Add<Name>(buttonEntity).Text = $"Button 0x{color:X6}";
        }
    }
}
