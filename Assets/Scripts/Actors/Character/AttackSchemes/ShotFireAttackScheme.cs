using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class ShotFireAttackScheme : FirearmAttackSceme<Shotgun>, IWeaponAttackScheme
    {
        public ShotFireAttackScheme(Shotgun weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            _attacker = attacker;
            _attacker.Controls.Character.Aim.canceled += callbackContext => Attack();
            _attacker.BulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            float delta = _weaponData.SpreadAngle / _weaponData.BulletsPerShot;
            float correctiveAngle = delta / 2;

            float startAngle = ~_weaponData.SpreadAngle / 2;
            startAngle += correctiveAngle;

            _attacker.CharacterControl.RotateFast();

            for (int i = 0; i < _weaponData.BulletsPerShot; i++)
            {
                _attacker.BulletDealer.GetBullet().transform.Rotate(0, startAngle, 0);
                startAngle += delta;
            }
        }

        void IWeaponAttackScheme.Cancel()
        {
            _attacker.Controls.Character.Aim.canceled -= callbackContext => Attack();
        }
    }
}