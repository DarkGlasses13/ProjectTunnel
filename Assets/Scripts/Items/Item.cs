using UnityEngine;

namespace Assets.Scripts
{
    public class Item : ScriptableObject
    {
        [SerializeField] protected int _id;
        [SerializeField] protected string _title;
        [SerializeField] protected Sprite _icon;

        public int Id => _id;
        public string Title => _title;
        public Sprite Icon => _icon;
    }
}