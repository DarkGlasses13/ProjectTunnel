using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class BulletDealer : MonoBehaviour
    {
        [SerializeField] [Range(10, 100)] private int _bulletPoolSize;

        private BulletFactory _bulletFactory;
        private List<Bullet> _bullets = new List<Bullet>();
        private Bullet _bulletPrefab;
        private Transform _bulletParent;

        [Inject] private void Construct(BulletFactory bulletFactory) => _bulletFactory = bulletFactory;

        public void InitPool(Bullet bulletPrefab, Transform bulletParent)
        {
            _bulletPrefab = bulletPrefab;
            _bulletParent = bulletParent;

            for (int i = 0; i < _bulletPoolSize; i++)
            {
                Bullet bullet = _bulletFactory.Create(bulletPrefab, _bulletParent);
                bullet.gameObject.SetActive(false);
                _bullets.Add(bullet);
                bullet.OnHit += Reload;
            }
        }

        public Bullet GetBullet()
        {
            foreach (Bullet bullet in _bullets)
            {
                if (bullet.gameObject.activeSelf == false)
                {
                    bullet.transform.SetParent(null);
                    bullet.gameObject.SetActive(true);
                    return bullet;
                }
            }

            return _bulletFactory.Create(_bulletPrefab, null);
        }

        public void Reload(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(_bulletParent);
            bullet.transform.localPosition = default;
            bullet.transform.localRotation = default;
            bullet.ClearTrail();
        }

        private void OnDisable()
        {
            foreach (Bullet bullet in _bullets)
                bullet.OnHit -= Reload;
        }
    }
}