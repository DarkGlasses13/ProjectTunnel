using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Weapon", fileName = "New Weapon Config")]
    public class WeaponConfig : Config
    {
        [SerializeField] float _multipleDamage;
        [SerializeField] float _weaponRecoil;

        public float MultipleDamage => _multipleDamage;
        public float WeaponRecoil => _weaponRecoil;
    }
}
