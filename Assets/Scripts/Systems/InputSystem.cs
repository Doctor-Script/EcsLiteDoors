using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLitDoors
{
    sealed class InputSystem : IEcsRunSystem
    {
        private readonly Camera _camera;

        public InputSystem(Camera camera) {
            _camera = camera;
        }

        public void Run(IEcsSystems systems)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var world = systems.GetWorld();
                    var filter = world.Filter<InputConsumer>().End();
                    var moveCommandPool = world.GetPool<MoveCommand>();

                    foreach (var entity in filter)
                    {
                        ref var moveCommand = ref moveCommandPool.GetOrAdd(entity);
                        moveCommand.Target = hit.point;
                    }
                }
            }
        }
    }
}
