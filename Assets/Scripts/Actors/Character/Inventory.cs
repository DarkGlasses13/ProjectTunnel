using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _hand;

        private Weapon _weapon;
        private Armor _armor;

        private ItemDatabase _itemDatabase;
        private Dictionary<int, Valuable> _valuebles;

        [Inject] private void Construct(ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        public void EquipWeapon(int id)
        {
            _weapon = _itemDatabase.GetItem<Weapon>(id);
            Instantiate(_weapon.Prefab.gameObject, _hand).GetComponent<Attacker>().SetAttackScheme(_weapon.AttackScheme);
        }

        public void RemoveValuable(int id) => _valuebles.Remove(id);

        public void TakeValuable(int id) => _valuebles.Add(id, _itemDatabase.GetItem<Valuable>(id));

    }
}