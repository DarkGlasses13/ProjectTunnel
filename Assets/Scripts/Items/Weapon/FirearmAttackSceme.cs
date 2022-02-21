using UnityEngine;

namespace Assets.Scripts
{
    public class FirearmAttackSceme<W> : WeaponAttackScheme<W> where W: Firearm
    {
        protected BulletDealer _bulletDealer;

        public FirearmAttackSceme(W weaponData) : base(weaponData) { }
    }
}