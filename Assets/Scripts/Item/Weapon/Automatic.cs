using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/AutomaticWeapon", fileName = "New Automatic Weapon")]
    public class Automatic : FireArm
    {
        [SerializeField] [Range(1, 5)] protected int _fireRate;

        public int FireRate => _fireRate;

        public Automatic()
        {
            _weaponScheme = new MultipleAttackScheme();
        }
    }
}
