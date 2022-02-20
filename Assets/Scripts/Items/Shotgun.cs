using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun", fileName = "New Shotgun")]
    public class Shotgun : Firearm
    {
        [SerializeField] [Range(3, 10)] protected int _bulletsPerShot;
        [SerializeField] [Range(0, 180)] protected int _spreadAngle;

        public int BulletsPerShot => _bulletsPerShot;
        public int SpreadAngle => _spreadAngle;

        public Shotgun() => _attackScheme = new ShotFireAttackScheme(this);
    }
}