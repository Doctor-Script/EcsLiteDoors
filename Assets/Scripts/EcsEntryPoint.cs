using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

namespace EcsLiteDoors
{
    public class EcsEntryPoint : MonoBehaviour
    {
        [SerializeField] private ViewsFactory _viewsFactory;
        
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
                .Add(new InitPlayerViewSystem(_viewsFactory))
                .Add(new InitButtonAndDoorViewsSystem(_viewsFactory))
                
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
