using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponModel : Model<WeaponConfig>
    {
        public Action<Weapon> OnWeaponChange;

        private Weapon _equippedWeapon;
        private IWeaponAttackScheme _attackScheme;
        private int _equippedWeaponDamage;
        private int _equippedWeaponFireRate;
        private int _equippedWeaponBulletPerShot;

        public int EquippedWeaponDamage => _equippedWeaponDamage;
        public int EquippedWeaponFireRate => _equippedWeaponFireRate;
        public int EquippedWeaponBulletPerShot => _equippedWeaponBulletPerShot;
        public Weapon EquippedWeapon => _equippedWeapon;
        public IWeaponAttackScheme AttackScheme => _attackScheme;

        public WeaponModel(WeaponConfig config) : base(config) { }

        protected override void SetConfig(WeaponConfig config)
        {

        }

        public void SetWeapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
            _attackScheme = _equippedWeapon.WeaponScheme;
            _equippedWeaponDamage = _equippedWeapon.Damage;
            _equippedWeaponFireRate = _equippedWeapon.AttackRate;
            _equippedWeaponBulletPerShot = _equippedWeapon.BulletsPerShot;

            OnWeaponChange?.Invoke(_equippedWeapon);
        }
        public Weapon GetWeaponDisplay()
        {
            return EquippedWeapon;
        }
    }
}
