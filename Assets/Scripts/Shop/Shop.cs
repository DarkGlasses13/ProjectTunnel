using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private EquipmentSet _playerEquipment;
        [SerializeField] private List<Product> _products;

        private void Awake()
        {
            foreach (Product product in _products)
            {
                product.OnBuy.AddListener(Sell);
            }
        }

        private void Sell(Item item)
        {

        }
    }
}