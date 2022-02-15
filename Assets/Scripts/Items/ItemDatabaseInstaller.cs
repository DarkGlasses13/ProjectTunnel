using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Zenject/Installer/Item Database Installer", fileName = "New Item Database Installer")]
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