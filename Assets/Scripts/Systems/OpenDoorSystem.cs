using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class OpenDoorSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<Collision>().End();

            foreach (var entity in filter)
            {
                var collision = world.Get<Collision>(entity);
                TryActivateButton(world, collision.ColliderEntity1);
                TryActivateButton(world, collision.ColliderEntity2);
            }
        }

        private void TryActivateButton(EcsWorld world, EcsPackedEntity packedEntity)
        {
            if (packedEntity.Unpack(world, out var buttonEntity))
            {
                var buttonsPool = world.GetPool<Button>();
                if (buttonsPool.Has(buttonEntity))
                {
                    var button = buttonsPool.Get(buttonEntity);
                    OpenDoorByButton(world, button);
                }
            }
        }

        private void OpenDoorByButton(EcsWorld world, Button button)
        {
            if (button.PackedDoorEntity.Unpack(world, out var doorEntity))
            {
                var doorsPool = world.GetPool<Door>();
                if (doorsPool.Has(doorEntity))
                {
                    ref var door = ref doorsPool.Get(doorEntity);
                    door.ClosedPercent -= 0.2f * Time.deltaTime;
                    if (door.ClosedPercent < 0f) {
                        door.ClosedPercent = 0f;
                    }
                }
            }
        }
    }
}
