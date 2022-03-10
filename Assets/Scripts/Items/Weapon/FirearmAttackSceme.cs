using UnityEngine;

namespace Assets.Scripts
{
    public class FirearmAttackSceme<W> : WeaponAttackScheme<W> where W: Firearm
    {
        public FirearmAttackSceme(W weaponData) : base(weaponData) { }
    }
}