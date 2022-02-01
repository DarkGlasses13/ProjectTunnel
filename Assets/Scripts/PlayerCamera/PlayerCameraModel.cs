using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraModel : Model<PlayerCameraConfig>
    {
        public Action<Vector3, int> OnPositionChanged;

        private Vector3 _offset;
        private Vector3 _position;
        private int _moveSpeed;

        public PlayerCameraModel(PlayerCameraConfig config) : base(config) { }

        protected override void SetConfig(PlayerCameraConfig config)
        {
            _moveSpeed = config.MoveSpeed;
        }

        public void SetNewPosition(Vector3 newPosition)
        {
            _position = newPosition;
            OnPositionChanged?.Invoke(_position, _moveSpeed);
        }
    }
}