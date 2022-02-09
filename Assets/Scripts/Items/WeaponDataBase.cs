using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Weapon/Database", fileName = "WeaponDatabase")]
    public class WeaponDataBase : ScriptableObject
    {
        [SerializeField] private List<Weapon> _weaponList = new List<Weapon>();

        private Dictionary<int, Weapon> _weaponBase = new Dictionary<int, Weapon>();

        public void Sort()
        {
            foreach (Weapon weapon in _weaponList)
            {
                _weaponBase.Add(weapon.ID, weapon);
            }
        }
        public Weapon GetWeapon(int id)
        {
            return _weaponBase[id];
        }
    }
}
