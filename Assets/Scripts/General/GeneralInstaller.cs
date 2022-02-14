using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GeneralInstaller : MonoInstaller
    {
        [SerializeField] private UpdateCacher _updateCacher;

        public override void InstallBindings()
        {
            BindUpdateCacher();
        }

        private void BindUpdateCacher()
        {
            Container
                .Bind<UpdateCacher>()
                .FromInstance(_updateCacher)
                .AsSingle()
                .NonLazy();
        }
    }
}