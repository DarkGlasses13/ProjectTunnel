using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Armor", fileName = "New Armor")]
    public class Armor : Equipment
    {
        [SerializeField] private int _defenceValue;
        [SerializeField] private ArmorType _type;

        public int DefenceValue => _defenceValue;
        public ArmorType Type => _type;
    }

    public enum ArmorType
    {
        Light,
        Medium,
        Heavy
    }
}