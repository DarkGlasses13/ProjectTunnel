
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : Item
    {
        [SerializeField] [Range(1, 100)] protected int _damage;
        [SerializeField] WeaponObj _weaponModel;

        protected IWeaponAttackScheme _weaponScheme;

        public IWeaponAttackScheme WeaponScheme => _weaponScheme;
        public int Damage => _damage;
        public WeaponObj Model => _weaponModel;
    }
}