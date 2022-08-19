using Leopotam.EcsLite;
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
                
                // Init 
                .Add(new InitPlayerSystem())
                .Add(new InitButtonsAndDoorsSystem())
                .Add(new InitButtonAndDoorViewsSystem(_viewsFactory))
                
                // Input
                .Add(new InputSystem(Camera.main))
                
                // Update Logic
                .Add(new MoveSystem())
                
                // Apply To Unity
                .Add(new UnityApplyStanceSystem())
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
