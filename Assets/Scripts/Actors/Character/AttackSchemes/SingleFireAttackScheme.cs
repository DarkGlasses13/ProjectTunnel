using UnityEngine;

namespace Assets.Scripts
{
    public class SingleFireAttackScheme : FirearmAttackSceme<Single>, IWeaponAttackScheme
    {
        public SingleFireAttackScheme(Single weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled += callbackContext => Attack();
            _bulletDealer = attacker.BulletDealer;
            _bulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            _bulletDealer.GetBullet();
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled -= callbackContext => Attack();
        }
    }
}