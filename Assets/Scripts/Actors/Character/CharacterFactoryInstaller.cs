using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class CharacterFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<Character, CharacterConfig, Transform, Vector3, Character, CharacterFactory>()
                .FromFactory<AdvancedCharacterFactory>();
        }
    }
}