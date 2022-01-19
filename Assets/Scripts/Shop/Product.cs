using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class Product : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Item> OnBuy;

        [SerializeField] private Item _item;

        private Button _button;
        private Image _image;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(Buy);
            _image.sprite = _item.Icon;
        }

        private void Buy()
        {

        }
    }
}