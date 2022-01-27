using UnityEngine;

namespace Assets.Scripts
{
    public class Item : ScriptableObject
    {
        [SerializeField] protected int _id;
        [SerializeField] protected string _title;
        [SerializeField] protected Sprite _icon;
        [SerializeField] protected GameObject _prefab;

        public int Id => _id;
        public string Title => _title;
        public Sprite Icon => _icon;
        public GameObject Prefab => _prefab;
    }
}