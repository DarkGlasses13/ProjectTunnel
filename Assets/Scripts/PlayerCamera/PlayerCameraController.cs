using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraController : Controller<PlayerCameraModel, PlayerCameraView, PlayerCameraConfig>
    {
        public PlayerCameraController(PlayerCameraModel model, PlayerCameraView view) : base(model, view)
        {
            _view.OnInOffset += ChangePosition;
            _model.OnPositionChanged += DisplayPosition;
        }

        private void DisplayPosition(Vector3 position, int speed)
        {
            _view.UpdatePosition(position, speed);
        }

        private void ChangePosition(Vector3 playerPosition)
        {
            Vector3 newPosition = playerPosition + _view.Offset;
            _model.SetNewPosition(newPosition);
        }

        ~PlayerCameraController()
        {
            _model.OnPositionChanged -= DisplayPosition;
            _view.OnInOffset -= ChangePosition;
        }
    }
}