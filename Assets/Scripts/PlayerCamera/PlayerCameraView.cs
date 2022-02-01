using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraView : View
    {
        public Action<Vector3> OnInOffset;

        [SerializeField] private PlayerView _playerView;

        public Vector3 Offset { get; private set; }

        private void OnEnable()
        {
            GameStartup.OnFixedUpdate += ReadPlayerPosition;
            Offset = transform.position;
        }

        private void ReadPlayerPosition()
        {
            if (transform.position != _playerView.transform.position + Offset)
                OnInOffset?.Invoke(_playerView.transform.position);
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