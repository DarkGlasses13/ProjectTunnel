using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Automatic", fileName = "New Automatic Weapon")]
    public class Automatic : Firearm
    {
        [SerializeField] [Range(0.1f, 1)] protected float _fireRate;

        public float FireRate => _fireRate;

        public Automatic()
        {
            _attackScheme = new ContinuousAttackScheme();
        }
    }
}