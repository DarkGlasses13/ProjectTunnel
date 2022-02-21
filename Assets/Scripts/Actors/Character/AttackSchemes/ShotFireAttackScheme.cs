using UnityEngine;

namespace Assets.Scripts
{
    public class ShotFireAttackScheme : FirearmAttackSceme<Shotgun>, IWeaponAttackScheme
    {
        public ShotFireAttackScheme(Shotgun weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled += callbackContext => Attack();
            _bulletDealer = attacker.BulletDealer;
            _bulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            float minAngle = -_weaponData.SpreadAngle / 2;
            float maxAngle = _weaponData.SpreadAngle / 2;

            for (int i = 0; i < _weaponData.BulletsPerShot; i++)
            {
                _bulletDealer.GetBullet().transform.rotation = Quaternion.AngleAxis(Random.Range(minAngle, maxAngle), Vector3.up);
            }
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled -= callbackContext => Attack();
        }
    }
}