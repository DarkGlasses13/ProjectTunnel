using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : Item
    {
        [SerializeField] [Range(1, 100)] protected int _damage;
        [SerializeField] [Range(0, 10)] protected int _bulletsPerShot;
        [SerializeField] [Range(1, 5)] protected int _attackRate;
        [SerializeField] WeaponObj _weaponModel;

        protected IWeaponAttackScheme _weaponScheme;

        public IWeaponAttackScheme WeaponScheme => _weaponScheme;
        public int Damage => _damage;
        public int BulletsPerShot => _bulletsPerShot;
        public int AttackRate => _attackRate;
        public WeaponObj Model => _weaponModel;
    }
}