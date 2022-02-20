using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvanceBulletDealerFactory : IFactory<BulletDealer, Transform, BulletDealer>
    {
        private DiContainer _container;

        public AdvanceBulletDealerFactory(DiContainer container) => _container = container;

        public BulletDealer Create(BulletDealer prefab, Transform parent)
        {
            BulletDealer bulletDealer = _container.InstantiatePrefabForComponent<BulletDealer>(prefab, parent);
            _container.Bind<BulletDealer>().FromInstance(bulletDealer);
            return bulletDealer;
        }
    }
}