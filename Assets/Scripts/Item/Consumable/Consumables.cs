using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
