using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : Equipment
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected WeaponType _weaponType;
        [SerializeField] protected AnimatorOverrideController _attackOverride;
        
        public int Damage => _damage;
        public AttackType AttackType { get; protected set; }
        public WeaponType WeaponType => _weaponType;
        public AnimatorOverrideController AttackOverride => _attackOverride;
    }

    public enum WeaponType
    {
        Fire,
        Melee
    }

    public enum AttackType
    {
        Single,
        Continuous
    }
}