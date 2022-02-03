using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : Controller<WeaponModel, WeaponView, WeaponConfig>
    {
        public WeaponController(WeaponModel model, WeaponView view) : base(model, view)
        {
            _model.OnWeaponChange += DisplayWeapon;
            _model.OnPosChange += TransferWeapon;
        }

        private void DisplayWeapon(Weapon weapon)
        {
            _view.ChangeWeapon(weapon);
        }
        private void TransferWeapon(Vector3 weaponPos)
        {
            _view.UpdateWeaponPos(weaponPos);
        }
        ~WeaponController()
        {
            _model.OnWeaponChange -= DisplayWeapon;
            _model.OnPosChange -= TransferWeapon;
        }
    }
}
