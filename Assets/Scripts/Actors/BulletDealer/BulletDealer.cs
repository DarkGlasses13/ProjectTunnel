using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BulletDealer : MonoBehaviour
    {
        [SerializeField] [Range(10, 100)] private int _poolSize;

        private List<Bullet> _bullets;
        private Transform _actorsParent;

        public void Init(Bullet bulletPrefab, Transform actorsParent)
        {
            _bullets = new List<Bullet>(_poolSize);
            _actorsParent = actorsParent;

            for (int i = 0; i < _poolSize; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab, transform);
                bullet.gameObject.SetActive(false);
            }
        }
    }
}