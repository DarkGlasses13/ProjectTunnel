using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponIcon : MonoBehaviour
    {
        [SerializeField] int _weaponId;

        private void OnMouseDown()
        {
            GameStartup.OnWeaponSet?.Invoke(_weaponId);
            Debug.Log("gg");
        }
    }
}
