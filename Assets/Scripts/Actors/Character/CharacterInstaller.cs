using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactory();
        }

        private void BindFactory()
        {
            Container
                .BindFactory<Character, CharacterConfig, Transform, Vector3, Character, CharacterFactory>()
                .FromFactory<AdvancedCharacterFactory>();
        }
    }
}