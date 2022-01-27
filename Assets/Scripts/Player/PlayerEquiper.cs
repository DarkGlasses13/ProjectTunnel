using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerEquiper : MonoBehaviour
    {
        [SerializeField] private EquipmentSet _set;
        [SerializeField] private Transform _hand;

        private void Start()
        {
            Equip();
        }

        private void Equip()
        {
            GameObject weapon = Instantiate(_set.Weapon.Prefab, _hand);
        }
    }
}