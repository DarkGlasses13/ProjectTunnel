using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class ShopInstaler : MonoInstaller
    {
        [SerializeField] Button _uziButton;
        [SerializeField] Button _glock17Button;

        public override void InstallBindings()
        {

        }
    }
}
