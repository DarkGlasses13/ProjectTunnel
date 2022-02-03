
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Weapon", fileName = "New Weapon Config")]
    public class WeaponConfig : Config
    {
        [SerializeField] [Range(1, 100)] private int bulletCount;
        [SerializeField] Bullet _bulletPrefab;

        [SerializeField] [Range(-1, 1)] private float _xPos;
        [SerializeField] [Range(-1, 1)] private float _yPos;
        [SerializeField] [Range(-1, 1)] private float _zPos;

        public float XPos => _xPos;
        public float YPos => _yPos;
        public float ZPos => _zPos;
        public int BulletCount => bulletCount;
        public Bullet BulletPrefab => _bulletPrefab;
    }
}
