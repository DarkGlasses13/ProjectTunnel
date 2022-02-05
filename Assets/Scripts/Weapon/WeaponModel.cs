using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponModel : Model<WeaponConfig>
    {
        public Action<Weapon> OnWeaponChange;

        private Weapon _equippedWeapon;
        public Weapon EquippedWeapon => _equippedWeapon;

        public WeaponModel(WeaponConfig config) : base(config) { }

        protected override void SetConfig(WeaponConfig config)
        {

        }

        public void SetWeapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
            OnWeaponChange?.Invoke(_equippedWeapon);
        }
        public Weapon GetWeaponDisplay()
        {
            return EquippedWeapon;
        }
    }
}
