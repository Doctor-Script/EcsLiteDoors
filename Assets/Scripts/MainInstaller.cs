using EcsLiteDoors;
using UnityEngine;
using Zenject;

namespace EcsLiteDoors
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private ViewsFactory _viewsFactory;

        public override void InstallBindings()
        {
            Container.Bind<ViewsFactory>().FromInstance(_viewsFactory);
        }
    }
}
