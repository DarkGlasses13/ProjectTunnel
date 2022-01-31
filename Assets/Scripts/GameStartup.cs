using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        public static Action OnUpdate;
        public static Action OnFixedUpdate;

        [Header("World")]
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Transform _worldParent;

        [Header("Player")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerVew _playerVew;

        [Header("Player Camera")]
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private PlayerCameraVew _playerCameraVew;

        private void Awake()
        {
            PlayerModel playerModel = new PlayerModel(_playerConfig);
            PlayerController playerController = new PlayerController(playerModel, _playerVew);
            _playerVew.SetController(playerController);

            PlayerCameraModel playerCameraModel = new PlayerCameraModel(_playerCameraConfig);
            PlayerCameraController playerCameraController = new PlayerCameraController(playerCameraModel, _playerCameraVew);
            _playerCameraVew.SetController(playerCameraController);
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