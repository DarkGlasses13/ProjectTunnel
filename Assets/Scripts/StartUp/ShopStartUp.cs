using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class ShopStartUp : MonoBehaviour, IStartUp
    {
        public static Action<int> OnWeaponSet;

        [SerializeField] Button _uziButton;
        [SerializeField] Button _glock17Button;

        [Header("Config")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private WeaponConfig _weaponConfig;

        [Header("World")]
        [SerializeField] private Transform _worldParent;
        [SerializeField] private WeaponDataBase _weaponDataBase;

        private PlayerView _playerView;
        private WeaponView _weaponView;

        [Inject]
        public void Construct(PlayerView player, WeaponView weapon)
        {
            _playerView = player;
            _weaponView = weapon;
            Init();
        }
        public void Init()
        {
            _uziButton.onClick.AddListener(() => _weaponView.GetWeaponId(1));
            _glock17Button.onClick.AddListener(() => _weaponView.GetWeaponId(0));

            _weaponDataBase.Sort();

            PlayerModel playerModel = new PlayerModel(_playerConfig);
            PlayerController playerController = new PlayerController(playerModel, _playerView);

            WeaponModel weaponModel = new WeaponModel(_weaponConfig);
            WeaponController weaponController = new WeaponController(weaponModel, _weaponView);
            weaponController.weaponOperation += _weaponDataBase.GetWeapon;
            OnWeaponSet += weaponController.SetNewWeapon;
        }
    }
}
