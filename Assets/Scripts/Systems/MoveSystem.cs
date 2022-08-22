using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class MoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MoveCommand>().Inc<Movable>().Inc<Transform2D>().End();
            
            var moveCommandPool = world.GetPool<MoveCommand>();
            var transformPool = world.GetPool<Transform2D>();
            var movablePool = world.GetPool<Movable>();

            foreach (var entity in filter)
            {
                ref var transform = ref transformPool.Get(entity);
                ref var movable = ref movablePool.Get(entity);
                ref var moveCommand = ref moveCommandPool.Get(entity);

                var moveDistance = UnityUtils.DeltaTime * movable.Speed;
                var totalMoveVector = moveCommand.Target - transform.Position;
                var direction = totalMoveVector.normalized;
                if (totalMoveVector.magnitude > moveDistance)
                {
                    transform.Position += moveDistance * direction;
                    transform.DirectionAngle = DirectionToDeg(direction);
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
