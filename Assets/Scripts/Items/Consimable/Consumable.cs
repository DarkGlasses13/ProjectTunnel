using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class Consumables : Item
    {
        [SerializeField] int refill;
        [SerializeField] protected ConsumablesType _consumables;

        public ConsumablesType ConsumablesSize => _consumables;
        public enum ConsumablesType
        {
            small,
            medium,
            large
        }
    }
}
