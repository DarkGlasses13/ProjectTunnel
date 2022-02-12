using UnityEngine;

namespace Assets.Scripts
{
    public class SingleAttackScheme : IWeaponAttackScheme 
    {
        public void Attack()
        {
            Debug.Log("Single Attack");
        }
    }
}