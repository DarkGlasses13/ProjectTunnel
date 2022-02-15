using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Icon : MonoBehaviour, IPointerClickHandler
    {
        public Action OnClick;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => OnClick?.Invoke();
    }
}