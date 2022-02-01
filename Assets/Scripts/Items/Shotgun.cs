using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun", fileName = "New Shotgun")]
    public class Shotgun : Firearm
    {
        [SerializeField] [Range(3, 10)] protected int _bulletsPerShot;

        public int BulletsPerShot => _bulletsPerShot;

        public Shotgun()
        {
            _attackScheme = new ShotAttackScheme();
        }
    }
}