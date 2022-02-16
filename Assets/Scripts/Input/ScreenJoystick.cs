using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [AddComponentMenu("Input/Screen Joystick")]
    public class ScreenJoystick : OnScreenControl, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private string _controlPath;
        [SerializeField] private Image _background;
        [SerializeField] private Image _handle;
        [SerializeField] [Range(10, 100)] private float _handleMoveRadius;
        [SerializeField] [Range(0, 100)] private float _deadzone;

        protected override string controlPathInternal 
        {
            get => _controlPath;
            set => _controlPath = value;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {

        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if 
            (
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                (
                    _background.rectTransform,
                    eventData.position,
                    eventData.pressEventCamera,
                    out Vector2 inputPosition
                )
            )
            {
                inputPosition.x = inputPosition.x / _background.rectTransform.sizeDelta.x;
                inputPosition.y = inputPosition.y / _background.rectTransform.sizeDelta.y;

                Vector2 handlePosition = - Vector2.ClampMagnitude
                (
                    new Vector2(inputPosition.x * _handleMoveRadius / 2,
                    inputPosition.y * _handleMoveRadius / 2),
                    _handleMoveRadius
                );

                if (handlePosition.magnitude < _deadzone)
                {
                    handlePosition = default;
                }

                _handle.rectTransform.anchoredPosition = handlePosition;
                SendValueToControl(handlePosition);
            }
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            _handle.rectTransform.anchoredPosition = default;
            SentDefaultValueToControl();
        }
    }
}