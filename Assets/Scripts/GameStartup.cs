using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        public static Action OnUpdate;
        public static Action OnFixedUpdate;
        public static Action<int> OnWeaponSet;

        [Header("World")]
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Transform _worldParent;
        [SerializeField] private ItemDataBase _database;

        [Header("Player")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerView _playerView;

        [Header("Player Camera")]
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private PlayerCameraView _playerCameraView;

        [Header("Player Weapon")]
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private WeaponView _weaponView;

        private void Awake()
        {
            _database.Sort();

            PlayerModel playerModel = new PlayerModel(_playerConfig);
            PlayerController playerController = new PlayerController(playerModel, _playerView);

            PlayerCameraModel playerCameraModel = new PlayerCameraModel(_playerCameraConfig);
            PlayerCameraController playerCameraController = new PlayerCameraController(playerCameraModel, _playerCameraView);

            WeaponModel weaponModel = new WeaponModel(_weaponConfig);
            WeaponController weaponController = new WeaponController(weaponModel, _weaponView);
            weaponController.itemOperation += _database.GetItem;
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