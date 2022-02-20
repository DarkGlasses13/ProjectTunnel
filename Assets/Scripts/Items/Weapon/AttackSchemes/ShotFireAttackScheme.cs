using UnityEngine;

namespace Assets.Scripts
{
    public class ShotFireAttackScheme : WeaponAttackScheme<Shotgun>, IWeaponAttackScheme
    {
        public ShotFireAttackScheme(Shotgun weaponData) : base(weaponData) { }

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