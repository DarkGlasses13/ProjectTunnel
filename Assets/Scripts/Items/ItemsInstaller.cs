using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ItemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindWeaponFactory();
        }

        private void BindWeaponFactory()
        {
            Container
                .BindFactory<EquipmentView, Transform, IWeaponAttackScheme, Attacker, WeaponFactory>()
                .FromFactory<AdvancedWeaponFactory>();
        }
    }
}