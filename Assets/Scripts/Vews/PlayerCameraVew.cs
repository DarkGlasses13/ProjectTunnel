using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraVew : Vew
    {
        public Action<Vector3> OnInOffset;

        [SerializeField] private PlayerVew _playerVew;

        public Vector3 Offset { get; private set; }

        private void OnEnable()
        {
            GameStartup.OnFixedUpdate += ReadPlayerPosition;
            Offset = transform.position;
        }

        private void ReadPlayerPosition()
        {
            if (transform.position != _playerVew.transform.position + Offset)
                OnInOffset?.Invoke(_playerVew.transform.position);
        }

        public void UpdatePosition(Vector3 updatedPosition, int speed)
        {
            transform.position = Vector3.Lerp(transform.position, updatedPosition, speed * Time.fixedDeltaTime);
        }

        private void OnDisable()
        {
            GameStartup.OnFixedUpdate -= ReadPlayerPosition;
        }
    }
}