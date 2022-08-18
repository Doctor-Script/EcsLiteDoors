using Leopotam.EcsLite;
using UnityEngine;

public class EcsEntryPoint : MonoBehaviour
{
    private EcsSystems _systems;

    void Start () {
        var world = new EcsWorld ();
        _systems = new EcsSystems (world);

        _systems
#if UNITY_EDITOR
            .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
            .Init ();
    }

    void Update () {
        _systems?.Run ();
    }

    void OnDestroy () {
        _systems?.Destroy ();
        _systems?.GetWorld ()?.Destroy ();
        _systems = null;
    }
}
