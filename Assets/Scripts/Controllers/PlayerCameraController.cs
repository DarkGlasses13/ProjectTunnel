using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraController : Controller<PlayerCameraModel, PlayerCameraVew, PlayerCameraConfig>
    {
        public PlayerCameraController(PlayerCameraModel model, PlayerCameraVew vew) : base(model, vew)
        {
            _vew.OnInOffset += ChangePosition;
            _model.OnPositionChanged += DisplayPosition;
        }

        private void DisplayPosition(Vector3 position, int speed)
        {
            _vew.UpdatePosition(position, speed);
        }

        private void ChangePosition(Vector3 playerPosition)
        {
            Vector3 newPosition = playerPosition + _vew.Offset;
            _model.SetNewPosition(newPosition);
        }

        ~PlayerCameraController()
        {
            _model.OnPositionChanged -= DisplayPosition;
            _vew.OnInOffset -= ChangePosition;
        }
    }
}