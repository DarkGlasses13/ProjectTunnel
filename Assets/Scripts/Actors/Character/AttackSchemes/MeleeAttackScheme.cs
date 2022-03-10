using UnityEngine;

namespace Assets.Scripts
{
    public class MeleeAttackScheme : WeaponAttackScheme<Melee>, IWeaponAttackScheme
    {
        public MeleeAttackScheme(Melee weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {

        }

        public void Attack()
        {
            Debug.Log("Melee Attack !");
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {

        }
    }
}