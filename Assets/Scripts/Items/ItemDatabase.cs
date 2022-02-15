using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Database", fileName = "ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private List<Item> _itemHeap = new List<Item>();

        private Dictionary<int, Item> _itemBase;

        public void OnValidate()
        {
            Sort();
        }

        public void Sort()
        {
            _itemBase = new Dictionary<int, Item>(_itemHeap.Count);
            _itemHeap.Sort();

            foreach (Item item in _itemHeap)
                _itemBase.Add(item.ID, item);
        }

        public T GetItem<T>(int id) where T: Item
        {
            return _itemBase[id] as T;
        }
    }
}