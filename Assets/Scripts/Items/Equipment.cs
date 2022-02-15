using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Equipment : Item
    {
        [SerializeField] private EquipmentView _prefab;

        public EquipmentView Prefab => _prefab;
    }
}