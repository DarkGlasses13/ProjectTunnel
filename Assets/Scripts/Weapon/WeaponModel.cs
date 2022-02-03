using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponModel : Model<WeaponConfig>
    {
        public Action<Weapon> OnWeaponChange;
        public Action<Vector3> OnPosChange;

        public delegate Item ItemOperation(int id);
        public ItemOperation itemOperation;

        private Item _equippedWeapon;

        public float XPos { get; private set; }
        public float YPos { get; private set; }
        public float ZPos { get; private set; }

        public WeaponModel(WeaponConfig config) : base(config) { }

        protected override void SetConfig(WeaponConfig config)
        {
            XPos = config.XPos;
            YPos = config.YPos;
            ZPos = config.ZPos;
        }

        public void SetNewWeapon(int weaponId)
        {
            _equippedWeapon = itemOperation?.Invoke(weaponId);
            Weapon weapon = _equippedWeapon as Weapon;
            OnWeaponChange?.Invoke(weapon);
        }

        public void SetWeaponPos()
        {
            Vector3 weaponPos = new Vector3(XPos, YPos, ZPos);
            OnPosChange?.Invoke(weaponPos);
        }
    }
}
