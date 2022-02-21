using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class IconDealer : MonoBehaviour
    {
        [SerializeField] int _itemPull;
        [SerializeField] CharacterConfig _config;

        private Dictionary<int, EquipmentView> _shopsAssortment;
        private EquipmentView _equipedWeapon;

        public void Init(Transform hand, Transform iconParent, Icon iconPrefab, ItemDatabase database)
        {
            _shopsAssortment = new Dictionary<int, EquipmentView>(_itemPull);
            for (int i = 0; i < _itemPull; i++)
            {
                Icon icon = Instantiate(iconPrefab, iconParent);
                Weapon weapon = database.GetItem<Weapon>(i);

                icon.OnClick += ChangeWeapon;
                icon.SettingIcon(weapon);

                CreateItemView(hand, weapon);
            }
        }

        public void ChangeWeapon(Weapon weapon)
        {
            if (_equipedWeapon != null)
            {
                _equipedWeapon.gameObject.SetActive(false);
            }
            _equipedWeapon = _shopsAssortment[weapon.ID];
            _equipedWeapon.gameObject.SetActive(true);
            _config.SetEquipedWeapon(weapon);
        }

        void CreateItemView(Transform hand, Weapon weapon)
        {
            EquipmentView equipment = Instantiate(weapon.Prefab, hand);
            _shopsAssortment.Add(weapon.ID, equipment);

            equipment.gameObject.SetActive(false);
        }
    }
}
