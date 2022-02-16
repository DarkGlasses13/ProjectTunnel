using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ActorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
                .BindFactory<Character, CharacterConfig, Transform, Vector3, Character, CharacterFactory>()
                .FromFactory<AdvancedCharacterFactory>();
        }
    }
}