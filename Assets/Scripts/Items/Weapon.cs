using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : Equipment
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected AnimatorOverrideController _attackOverride;
        
        public int Damage => _damage;
        public AttackType AttackType { get; protected set; }
        public AnimatorOverrideController AttackOverride => _attackOverride;
    }

    public enum AttackType
    {
        Single,
        Continuous
    }
}