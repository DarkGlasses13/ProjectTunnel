using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Equipment : Item
    {
        [SerializeField] protected GameObject _vew;

        public GameObject Vew => _vew;
    }
}