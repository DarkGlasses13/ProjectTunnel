using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraController : Controller<PlayerCameraModel, PlayerCameraVew, PlayerCameraConfig>
    {
        public PlayerCameraController(PlayerCameraModel model, PlayerCameraVew vew) : base(model, vew)
        {
            _model.OnPositionChanged += DisplayPosition;
            _vew.OnPlayerMove += ChangePosition;
        }

        ~PlayerCameraController()
        {
            _model.OnPositionChanged -= DisplayPosition;
            _vew.OnPlayerMove -= ChangePosition;
        }

        private void DisplayPosition(Vector3 position)
        {
            _vew.UpdatePosition(position);
        }

        private void ChangePosition(Vector3 playerPosition)
        {
            Vector3 newPosition = new Vector3(0, 30, playerPosition.z - 10);
            _model.SetNewPosition(newPosition);
        }
    }
}