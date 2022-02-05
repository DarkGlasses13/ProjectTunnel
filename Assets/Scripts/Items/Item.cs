using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] protected int _price;
    [SerializeField] protected int _id;
    [SerializeField] protected string _itemName;
    [SerializeField] [TextArea(1, 100)] protected string _description;
    [SerializeField] protected Sprite _icon;

    public int Prise => _price;
    public int ID => _id;
    public string ItemName => _itemName;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int CompareTo(object obj)
    {
        Item item = obj as Item;
        return _id.CompareTo(item.ID);
    }
}