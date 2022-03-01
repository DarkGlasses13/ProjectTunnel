using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedCharacterFactory : PlaceholderFactory<Character, CharacterConfig, Transform, Vector3, Character>, IFactory<Character, CharacterConfig, Transform, Vector3, Character>
    {
        private DiContainer _container;

        public AdvancedCharacterFactory(DiContainer container) => _container = container;

        new public Character Create(Character prefab, CharacterConfig config, Transform parent, Vector3 position)
        {
            Character character =
                GetSpawnedInstance(prefab, parent, position);
                Equip(character, config);

            return character;
        }

        private void Equip(Character character, CharacterConfig config)
        {
            Inventory inventory = character.GetComponent<Inventory>();
            inventory.EquipWeapon(config.EquipedWeapon.ID);
        }

        private Character GetSpawnedInstance(Character prefab, Transform parent, Vector3 position)
        {
            return _container.InstantiatePrefabForComponent<Character>(prefab.gameObject, position, Quaternion.identity, parent);
        }
    }
}