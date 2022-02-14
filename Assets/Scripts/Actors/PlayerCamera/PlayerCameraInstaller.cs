using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class PlayerCameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactory();
        }

        private void BindFactory()
        {
            Container
                .BindFactory<PlayerCamera, PlayerCameraConfig, Transform, Character, PlayerCamera, PlayerCameraFactory>()
                .FromFactory<AdvancedPlayerCameraFactory>();
        }
    }
}