using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AdvancedPlayerCameraFactory : IFactory<PlayerCamera, PlayerCameraConfig, Transform, Character, PlayerCamera>
    {
        private DiContainer _container;

        public AdvancedPlayerCameraFactory(DiContainer container) => _container = container;

        public PlayerCamera Create(PlayerCamera prefab, PlayerCameraConfig config, Transform parent, Character character)
        {
            if (character != default)
            {
                PlayerCamera playerCamera = _container.InstantiatePrefabForComponent<PlayerCamera>(prefab.gameObject);
                playerCamera.transform.SetParent(parent);
                playerCamera.SetCharacter(character);
                return playerCamera;
            }

            throw new Exception("Player Camera : Player Was Not Found");
        }
    }
}