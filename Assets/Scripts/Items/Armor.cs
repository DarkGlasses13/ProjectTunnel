using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Armor", fileName = "New Armor")]
    public class Armor : Equipment
    {
        [SerializeField] private ArmorType _armorType;
        [SerializeField] private int _protection;

        public ArmorType ArmorType => _armorType;
        public int Protection => _protection;
    }

    public enum ArmorType
    {
        Light,
        Medium,
        Heavy
    }
}