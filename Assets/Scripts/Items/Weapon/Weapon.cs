using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : Equipment
    {
        [SerializeField] [Range(1, 1000)] protected int _damage;

        protected IWeaponAttackScheme _attackScheme;

        public int Damage => _damage;
        public IWeaponAttackScheme AttackScheme => _attackScheme;
    }
}