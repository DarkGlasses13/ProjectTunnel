using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Weapon/ContinuousAttackable", fileName = "New Weapon")]
    public class ContinuousAttackable : Weapon
    {
        [SerializeField] [Range(0.1f, 1f)] private float _timeBetweenAttack;

        public float TimeBetweenAttack => _timeBetweenAttack;

        public ContinuousAttackable()
        {
            AttackType = AttackType.Continuous;
        }
    }
}