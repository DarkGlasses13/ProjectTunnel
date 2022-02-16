using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedBulletDealerFactory : IFactory<BulletDealer, Bullet, Transform, BulletDealer>
    {
        private DiContainer _container;
        public AdvancedBulletDealerFactory(DiContainer container) => _container = container;

        public BulletDealer Create(BulletDealer prefab, Bullet bulletPrefab, Transform parent)
        {
            BulletDealer bulletDealer = _container.InstantiatePrefabForComponent<BulletDealer>(prefab.gameObject);
            bulletDealer.transform.SetParent(parent);
            bulletDealer.Init(bulletPrefab, parent);
            _container.Bind<BulletDealer>().FromInstance(bulletDealer).AsSingle();
            return bulletDealer;
        }
    }
}