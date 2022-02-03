
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Weapon", fileName = "New Weapon Config")]
    public class WeaponConfig : Config
    {
        [SerializeField] [Range(1, 100)] private int bulletCount;
        [SerializeField] Bullet _bulletPrefab;

        public int BulletCount => bulletCount;
        public Bullet BulletPrefab => _bulletPrefab;
    }
}
