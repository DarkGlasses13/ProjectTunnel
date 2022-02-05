using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Database", fileName = "ItemDatabase")]
    public class ItemDataBase : ScriptableObject
    {
        [SerializeField] private List<Item> _itemList = new List<Item>();

        private Dictionary<int, Item> _itemBase = new Dictionary<int, Item>();

        public void Sort()
        {
            foreach (Item item in _itemList)
            {
                _itemBase.Add(item.ID, item);
            }
        }
        public Item GetItem(int id)
        {
            return _itemBase[id];
        }
    }
}
