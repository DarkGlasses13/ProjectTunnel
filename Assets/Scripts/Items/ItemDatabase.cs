using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Database", fileName = "ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private List<Item> _itemHeap = new List<Item>();

        private Dictionary<int, Item> _itemBase = new Dictionary<int, Item>();

        public void Sort()
        {
            _itemHeap.Sort();

            foreach (Item item in _itemHeap)
                _itemBase.Add(item.ID, item);
        }

        public Item GetItem(int id)
        {
            return _itemHeap[id];
        }
    }
}