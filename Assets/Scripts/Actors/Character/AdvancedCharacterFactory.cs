using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedCharacterFactory : IFactory<Character, CharacterConfig, Transform, Vector3, Character>
    {
        private DiContainer _container;

        public AdvancedCharacterFactory(DiContainer container) => _container = container;

        public Character Create(Character prefab, CharacterConfig config, Transform parent, Vector3 position)
        {
            Character character =
                GetSpawnedCharacter(prefab, parent, position);
                Equip(character, config);

            return character;
        }

        private void Equip(Character character, CharacterConfig config)
        {
            Inventory inventory = character.GetComponent<Inventory>();

            inventory.EquipWeapon(config.EquipedWeapon.ID);
        }

        private Character GetSpawnedCharacter(Character prefab, Transform parent, Vector3 position)
        {
            Character character = _container.InstantiatePrefabForComponent<Character>(prefab.gameObject);
            character.transform.SetParent(parent);
            character.transform.position = position;
            return character;
        }
    }
}