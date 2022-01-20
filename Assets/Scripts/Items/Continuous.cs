using UnityEngine;

namespace Assets.Scripts
{
    public class Continuous : Weapon
    {
        [SerializeField] [Range(0.1f, 1)] private float _timeBetweenAttack;

        public float TimeBetweenAttack => _timeBetweenAttack;

        public Continuous()
        {
            AttackType = AttackType.Continuous;
        }
    }
}