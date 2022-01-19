using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Equipment Set", fileName = "New Equipment Set")]
    public class EquipmentSet : ScriptableObject
    {
        [SerializeField] private Weapon _weapon;

        public Weapon Weapon => _weapon;

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}