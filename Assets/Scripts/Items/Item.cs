using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Item : ScriptableObject, IComparable
    {
        [SerializeField] protected int _id;
        [SerializeField] protected string _title;
        [SerializeField] protected int _price;
        [SerializeField] [TextArea(5, 500)] protected string _description;
        [SerializeField] private Sprite _icon;

        public int ID => _id;
        public string Title => _title;
        public int Price => _price;
        public string Description => _description;
        public Sprite Icon => _icon;

        public int CompareTo(object obj)
        {
            Item item = obj as Item;
            return _id.CompareTo(item.ID);
        }
    }
}