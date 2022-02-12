using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponView : View
    {
        public Action<int> OnGetId;
        public Action OnWeaponAttack;

        [SerializeField] Transform _hand;

        private WeaponObj _previoslyWeaponModel;
        public void ChangeWeapon(Weapon weapon)
        {
            WeaponObj model = Instantiate(weapon.Model, _hand);
            if (_previoslyWeaponModel == null)
            {
                _previoslyWeaponModel = model;
            }
            else
            {
                Destroy(_previoslyWeaponModel.gameObject);
                _previoslyWeaponModel = model;
            }
        }
        public void Attack()
        {
            OnWeaponAttack?.Invoke();
        }
        public void GetWeaponId(int id)
        {
            OnGetId?.Invoke(id);
        }
    }
}
