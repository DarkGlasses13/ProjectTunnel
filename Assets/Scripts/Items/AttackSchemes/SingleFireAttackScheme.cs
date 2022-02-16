using UnityEngine;

namespace Assets.Scripts
{
    public class SingleFireAttackScheme : IWeaponAttackScheme
    {
        private Single _weaponData;

        public SingleFireAttackScheme(Single weaponData) => _weaponData = weaponData;

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