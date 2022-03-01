using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ActorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBulletFactory();
            BindBulletDealerFactory();
            BindCharacterFactory();
            BindPlayerCameraFactory();
        }

        private void BindPlayerCameraFactory()
        {
            Container
                .BindFactory<PlayerCamera, PlayerCameraConfig, Transform, Character, PlayerCamera, PlayerCameraFactory>()
                .FromFactory<AdvancedPlayerCameraFactory>();
        }

        private void BindCharacterFactory()
        {
            Container
                .BindFactory<Character, CharacterConfig, Transform, Vector3, Character, AdvancedCharacterFactory>();
        }

        private void BindBulletDealerFactory()
        {
            Container
                .BindFactory<BulletDealer, Transform, BulletDealer, BulletDeallerFactory>()
                .FromFactory<AdvanceBulletDealerFactory>();
        }

        private void BindBulletFactory()
        {
            Container
                .BindFactory<Bullet, Transform, Bullet, BulletFactory>()
                .FromFactory<AdvancedBulletFactory>();
        }
    }
}