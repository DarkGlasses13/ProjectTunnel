using UnityEngine;

namespace Assets.Scripts
{
    public class SingleFireAttackScheme : WeaponAttackScheme<Single>, IWeaponAttackScheme
    {
        public SingleFireAttackScheme(Single weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled += callbackContext => Attack();
        }

        public void Attack()
        {
            Debug.Log("Single Attack !");
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled -= callbackContext => Attack();
        }
    }
}