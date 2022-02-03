using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public abstract class Weapon : Item
    {
        [SerializeField] [Range(1, 100)] protected int _damage;

        protected IWeaponAttackScheme _weaponScheme;

        public IWeaponAttackScheme WeaponScheme => _weaponScheme;
        public int Damage => _damage;
    }
}
