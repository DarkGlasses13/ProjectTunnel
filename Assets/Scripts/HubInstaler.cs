using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class HubInstaler : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindShopFactory();
        }

        void BindShopFactory()
        {
            Container
                .BindFactory<IconDealer, Icon, ItemDatabase, Transform, Transform, Transform, IconDealer, ShopFactory>()
                .FromFactory<AdvancedShopFactory>();
        }
    }
}
