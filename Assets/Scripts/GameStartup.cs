using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        public static Action OnUpdate;
        public static Action OnFixedUpdate;
        public static Action<int> OnWeaponSet;

        [Header("Config")]
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private GameConfig _gameConfig;

        [Header("View")]
        private PlayerView _playerView;
        private WeaponView _weaponView;
        [SerializeField] private PlayerCameraView _playerCameraView;

        [Header("World")]
        [SerializeField] private Transform _worldParent;
        [SerializeField] private WeaponDataBase _weaponDataBase;

        [Inject]
        public void Construct(PlayerView player, WeaponView weapon)
        {
            _playerView = player;
            _weaponView = weapon;
            Init();
        }
        private void Init()
        {
            _weaponDataBase.Sort();

            PlayerModel playerModel = new PlayerModel(_playerConfig);
            PlayerController playerController = new PlayerController(playerModel, _playerView);

            PlayerCameraModel playerCameraModel = new PlayerCameraModel(_playerCameraConfig);
            PlayerCameraController playerCameraController = new PlayerCameraController(playerCameraModel, _playerCameraView, _playerView.transform);

            WeaponModel weaponModel = new WeaponModel(_weaponConfig);
            WeaponController weaponController = new WeaponController(weaponModel, _weaponView);
            weaponController.weaponOperation += _weaponDataBase.GetWeapon;
            OnWeaponSet += weaponController.SetNewWeapon;
            //_weaponView.InitBulletPull(_weaponConfig.BulletCount, _weaponConfig.BulletPrefab);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

    }
}