using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedWeaponFactory : IFactory<EquipmentView, Transform, IWeaponAttackScheme, Attacker>
    {
        private DiContainer _container;

        public AdvancedWeaponFactory(DiContainer container) => _container = container;

        public Attacker Create(EquipmentView prefab, Transform hand, IWeaponAttackScheme attackScheme)
        {
            Attacker attacker = _container.InstantiatePrefabForComponent<Attacker>(prefab.gameObject);
            attacker.transform.SetParent(hand);
            attacker.transform.localPosition = default;
            attacker.SetControls(_container.Resolve<Controls>());
            attacker.SetCoroutineService(_container.Resolve<CoroutineService>());
            attacker.SetAttackScheme(attackScheme);
            return attacker;
        }
    }
}