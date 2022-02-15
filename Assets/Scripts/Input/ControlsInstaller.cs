using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ControlsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<Controls>()
                .FromInstance(new Controls())
                .AsSingle();
        }
    }
}