using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Equipment : Item
    {
        [SerializeField] protected Vew _vew;

        public Vew Vew => _vew;
    }

    public enum EquipmentType
    {
        Weapon,
        Armor
    }
}