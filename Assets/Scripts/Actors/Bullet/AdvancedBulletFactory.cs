using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedBulletFactory : IFactory<Bullet, Transform, Bullet>
    {
        private DiContainer _container;

        public AdvancedBulletFactory(DiContainer container) => _container = container;

        public Bullet Create(Bullet prefab, Transform container)
        {
            Bullet bullet = _container.InstantiatePrefabForComponent<Bullet>(prefab.gameObject, container);
            bullet.gameObject.SetActive(false);
            return bullet;
        }
    }
}