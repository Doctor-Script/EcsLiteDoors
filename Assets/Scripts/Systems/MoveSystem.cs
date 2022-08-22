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
            var stancePool = world.GetPool<Stance>();
            var movablePool = world.GetPool<Movable>();

            foreach (var entity in filter)
            {
                ref var stance = ref stancePool.Get(entity);
                ref var movable = ref movablePool.Get(entity);
                ref var moveCommand = ref moveCommandPool.Get(entity);

                float distanceForFrame = UnityUtils.DeltaTime * movable.Speed;
                var moving = moveCommand.Target - stance.Position;
                var direction = moving.normalized;
                if (moving.magnitude > distanceForFrame)
                {
                    stance.Position += distanceForFrame * direction;
                    stance.DirectionDeg = DirectionToDeg(direction);
                } else {
                    moveCommandPool.Del(entity);
                }
            }
        }

        private float DirectionToDeg(Vector3 direction) {
            return Vector2.SignedAngle(direction, Vector2.up);
        }
    }
}
