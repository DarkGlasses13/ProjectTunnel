using UnityEngine;

namespace Assets.Scripts
{
    public class Attacker : MonoBehaviour
    {
        private IWeaponAttackScheme _attackScheme;

        public void SetAttackScheme(IWeaponAttackScheme attackScheme)
        {
            _attackScheme = attackScheme;
            _attackScheme.Apply(this);
        }

        public void Attack()
        {
            Debug.Log("Attack");
        }
    }
}