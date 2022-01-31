using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraVew : Vew
    {
        public Action<Vector3> OnPlayerMove;

        [SerializeField] private PlayerController _playerController;

        private void OnEnable()
        {
            _playerController.OnMove += ReadPlayerPosition;
        }

        private void ReadPlayerPosition()
        {
            OnPlayerMove.Invoke(_playerController.transform.position);
        }

        public void UpdatePosition(Vector3 updatedPosition) => transform.position = updatedPosition;

        private void OnDisable()
        {
            _playerController.OnMove -= ReadPlayerPosition;
        }
    }
}