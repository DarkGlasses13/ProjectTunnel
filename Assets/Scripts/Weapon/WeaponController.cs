using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : Controller<WeaponModel, WeaponView, WeaponConfig>
    {
        public delegate Item ItemOperation(int id);
        public ItemOperation itemOperation;
        public WeaponController(WeaponModel model, WeaponView view) : base(model, view)
        {
            _model.OnWeaponChange += _view.ChangeWeapon;
            _view.OnGetId += SetNewWeapon;
        }
        public void SetNewWeapon(int weaponId)
        {
            Weapon weapon = itemOperation?.Invoke(weaponId) as Weapon;
            _model.SetWeapon(weapon);
        }
        ~WeaponController()
        {
            _model.OnWeaponChange -= _view.ChangeWeapon;
        }
    }
}
