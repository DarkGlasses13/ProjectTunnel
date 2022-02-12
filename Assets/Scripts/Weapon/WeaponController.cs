using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : Controller<WeaponModel, WeaponView, WeaponConfig>
    {
        public delegate Weapon WeaponOperation(int id);
        public WeaponOperation weaponOperation;
        public WeaponController(WeaponModel model, WeaponView view) : base(model, view)
        {
            _model.OnWeaponChange += _view.ChangeWeapon;
            _view.OnGetId += SetNewWeapon;
            _view.OnWeaponAttack += BulletInit;
        }
        public void SetNewWeapon(int weaponId)
        {
            var weapon = weaponOperation?.Invoke(weaponId);
            _model.SetWeapon(weapon);
        }
        public void BulletInit()
        {
            _model.AttackScheme.Attack();
        }
        ~WeaponController()
        {
            _model.OnWeaponChange -= _view.ChangeWeapon;
        }
    }
}
