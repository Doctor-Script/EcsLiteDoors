using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Zenject;

namespace EcsLiteDoors
{
    public class EcsEntryPoint : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        
        private EcsSystems _systems;

        void Start()
        {
            var world = new EcsWorld();
            _systems = new EcsSystems(world);

            _systems
                
                // Init Logic 
                .Add(new InitPlayerSystem())
                .Add(new InitButtonsAndDoorsSystem())
                
                // Init Views for Unity
                .Add(_diContainer.Instantiate<InitPlayerViewSystem>())
                .Add(_diContainer.Instantiate<InitButtonAndDoorViewsSystem>())

                // Input (Unity)
                .Add(new InputSystem(Camera.main))
                
                // Update Logic
                .Add(new MoveSystem())
                .Add(new CircleCollisionsSystem())
                .Add(new OpenDoorSystem())

                // Apply To Unity
                .Add(new UnityApplyTransformSystem())
                .Add(new UnityApplyDoorSystem())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .DelHere<Collision>()
                
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
