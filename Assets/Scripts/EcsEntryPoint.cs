using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

namespace EcsLitDoors
{
    public class EcsEntryPoint : MonoBehaviour
    {
        private EcsSystems _systems;

        void Start()
        {
            var world = new EcsWorld();
            _systems = new EcsSystems(world);

            _systems
                .Add(new InitPlayerSystem())
                .Add(new InputSystem(Camera.main))
                .Add(new MoveSystem())
                .Add(new UnityApplyMovableSystem())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            _systems?.Destroy();
            _systems?.GetWorld()?.Destroy();
            _systems = null;
        }
    }
}
