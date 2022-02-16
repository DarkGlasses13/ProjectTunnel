using UnityEngine;

namespace Assets.Scripts
{
    public class ShotFireAttackScheme : IWeaponAttackScheme
    {
        private Shotgun _weaponData;

        public ShotFireAttackScheme(Shotgun weaponData) => _weaponData = weaponData;

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled += callbackContext => Attack();
        }

        public void Attack()
        {
            Debug.Log("Shot Attack !");
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled -= callbackContext => Attack();
        }
    }
}