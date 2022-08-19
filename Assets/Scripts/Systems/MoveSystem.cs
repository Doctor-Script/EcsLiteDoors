using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class MoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MoveCommand>().Inc<Movable>().Inc<Stance>().End();
            var moveCommandPool = world.GetPool<MoveCommand>();

            foreach (var entity in filter)
            {
                ref var stance = ref world.GetPool<Stance>().Get(entity);
                ref var movable = ref world.GetPool<Movable>().Get(entity);
                ref var moveCommand = ref moveCommandPool.Get(entity);

                float distanceForFrame = UnityUtils.DeltaTime * movable.Speed;
                Vector3 moving = moveCommand.Target - stance.Position;
                Vector3 direction = moving.normalized;
                if (moving.magnitude > distanceForFrame)
                {
                    stance.Position += distanceForFrame * direction;
                    stance.Angle = DirectionToDeg(direction);
                } else {
                    moveCommandPool.Del(entity);
                }
            }
        }

        private float DirectionToDeg(Vector3 direction) {
            return Vector2.SignedAngle(new Vector2(direction.x ,direction.z), Vector2.up);
        }
    }
}
