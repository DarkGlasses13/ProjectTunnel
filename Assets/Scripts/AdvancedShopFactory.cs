using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedShopFactory : IFactory<IconDealer, Icon, ItemDatabase, Transform, Transform, Transform, IconDealer>
    {
        private DiContainer _container;

        public AdvancedShopFactory(DiContainer container) => _container = container;

        public IconDealer Create(IconDealer pref, Icon iconPref, ItemDatabase database, Transform hand, Transform iconParent, Transform dealerParent)
        {
            IconDealer iconDealer = _container.InstantiatePrefabForComponent<IconDealer>(pref.gameObject);
            iconDealer.transform.SetParent(dealerParent);
            iconDealer.Init(hand, iconParent, iconPref, database);
            return iconDealer;
        }
    }
}
