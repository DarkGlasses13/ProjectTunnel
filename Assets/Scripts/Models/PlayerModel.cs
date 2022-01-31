using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerModel : Model<PlayerConfig>
    {
        public Action<Vector3> OnMotionChanged;

        private Vector3 _motion;
        private Vector3 _lookDirection;

        public int MoveSpeed { get; private set; }
        public int RotationSpeed { get; private set; }

        public PlayerModel(PlayerConfig config) : base(config) { }

        protected override void SetConfig(PlayerConfig config)
        {
            MoveSpeed = config.MoveSpeed;
            RotationSpeed = config.RotationSpeed;
        }

        public void SetNewMotion(Vector3 newMotion)
        {
            _motion = newMotion;
            OnMotionChanged.Invoke(_motion);
        }

    }
}