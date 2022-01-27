using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Weapon/SingleAttackable", fileName = "New Weapon")]
    public class SingleAttackable : Weapon
    {
        public SingleAttackable()
        {
            AttackType = AttackType.Single;
        }
    }
}