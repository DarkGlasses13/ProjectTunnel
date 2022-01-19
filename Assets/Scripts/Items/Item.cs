using UnityEngine;

namespace Assets.Scripts
{
    public class Item : ScriptableObject
    {
        [SerializeField] protected int _id;
        [SerializeField] protected string _title;
        [SerializeField] protected ItemType _type;
        [SerializeField] protected Sprite _icon;

        public int Id => _id;
        public string Title => _title;
        public ItemType Type => _type;
        public Sprite Icon => _icon;
    }

    public enum ItemType
    {
        Weapon,
        Armor
    }
}