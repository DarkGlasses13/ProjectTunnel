using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Character", fileName = "New Character Config")]
    public class CharacterConfig : Config
    {
        [SerializeField] private Weapon _equipedWeapon;
        [SerializeField] private Armor _equipedArmor;

        public Weapon EquipedWeapon => _equipedWeapon;
        public Armor EquipedArmor => _equipedArmor;
    }
}