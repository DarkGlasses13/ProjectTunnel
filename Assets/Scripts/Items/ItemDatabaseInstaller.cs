using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ItemDatabaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ItemDatabase>()
                .FromScriptableObjectResource("Items/ItemDatabase")
                .AsSingle();
        }
    }
}