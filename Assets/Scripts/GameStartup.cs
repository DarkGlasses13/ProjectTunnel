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

        [Header("Player Camera")]
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private PlayerCameraVew _playerCameraVew;

        private void Awake()
        {
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