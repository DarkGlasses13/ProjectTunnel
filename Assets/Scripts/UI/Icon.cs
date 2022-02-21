using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Icon : MonoBehaviour, IPointerClickHandler
    {
        private Weapon _iconWeapon;

        public Action<Weapon> OnClick;

        public void SettingIcon(Weapon weapon)
        {
            _iconWeapon = weapon;

            Image image = GetComponent<Image>();
            image.sprite = _iconWeapon.Icon;
        }
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => OnClick?.Invoke(_iconWeapon);
    }
}