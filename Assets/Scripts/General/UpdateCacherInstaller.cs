using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(UpdateCacher))]
    public class UpdateCacherInstaller : MonoInstaller
    {
        private UpdateCacher _updateCacher;

        public override void InstallBindings()
        {
            _updateCacher = GetComponent<UpdateCacher>();

            Container
                .Bind<UpdateCacher>()
                .FromInstance(_updateCacher)
                .AsSingle()
                .NonLazy();
        }
    }
}