using UnityEngine;

namespace Assets.Scripts
{
    public class ContinuousAttackScheme : IWeaponAttackScheme
    {
        public void Attack()
        {
            Debug.Log("Continuous Attack");
        }
    }
}