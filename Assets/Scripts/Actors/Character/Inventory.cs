using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _hand;

        private Weapon _weapon;
        private WeaponFactory _weaponFactory;
        private Armor _armor;
        private ItemDatabase _itemDatabase;
        private Dictionary<int, Valuable> _valuebles;

        [Inject] private void Construct(ItemDatabase itemDatabase, WeaponFactory weaponFactory)
        {
            _itemDatabase = itemDatabase;
            _weaponFactory = weaponFactory;
        }

        public void EquipWeapon(int id)
        {
            _weapon = _itemDatabase.GetItem<Weapon>(id);
            _weaponFactory.Create(_weapon.Prefab, _hand, _weapon.AttackScheme);
        }

        public void RemoveValuable(int id) => _valuebles.Remove(id);

        public void TakeValuable(int id) => _valuebles.Add(id, _itemDatabase.GetItem<Valuable>(id));

    }
}