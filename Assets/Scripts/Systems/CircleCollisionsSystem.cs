using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteDoors
{
    sealed class CircleCollisionsSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<CircleCollider>().Inc<Stance>().End();

            var stancePool = world.GetPool<Stance>();
            var colliderPool = world.GetPool<CircleCollider>();
            var collisionsPool = world.GetPool<Collision>();

            int[] entities = filter.GetRawEntities();
            var entitiesCount = filter.GetEntitiesCount();
            for (int i = 0; i < entitiesCount; i++)
            {
                for (int j = i + 1; j < entitiesCount; j++)
                {
                    var entity1 = entities[i];
                    var entity2 = entities[j];
                    
                    ref var stance1 = ref stancePool.Get(entity1);
                    ref var stance2 = ref stancePool.Get(entity2);
                    
                    ref var collider1 = ref colliderPool.Get(entity1);
                    ref var collider2 = ref colliderPool.Get(entity2);
                    
                    var minDistance = collider1.Radius + collider2.Radius;
                    var sqrDistance = Vector2.SqrMagnitude(stance1.Position - stance2.Position);
                    if (sqrDistance < minDistance * minDistance)
                    {
                        var collisionEntity = world.NewEntity();
                        ref var collision = ref collisionsPool.Add(collisionEntity);
                        collision.ColliderEntity1 = world.PackEntity(entity1);
                        collision.ColliderEntity2 = world.PackEntity(entity2);
                    }
                }
            }
        }
    }
}
