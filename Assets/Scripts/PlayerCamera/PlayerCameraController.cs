using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraController : Controller<PlayerCameraModel, PlayerCameraView, PlayerCameraConfig>
    {
        private Transform _player;

        public PlayerCameraController(PlayerCameraModel model, PlayerCameraView view, Transform player) : base(model, view)
        {
            _player = player;
            GameStartup.OnFixedUpdate += ReadPlayerPosition;
            _model.OnPositionChanged += _view.UpdatePosition;
        }

        private void ReadPlayerPosition()
        {
            if (_view.transform.position != _player.transform.position)
                ChangePosition(_player.position);
        }

        private void ChangePosition(Vector3 playerPosition)
        {
            Vector3 newPosition = new Vector3(0, 0, playerPosition.z);
            _model.SetNewPosition(newPosition);
        }

        ~PlayerCameraController()
        {
            GameStartup.OnFixedUpdate -= ReadPlayerPosition;
            _model.OnPositionChanged -= _view.UpdatePosition;
        }
    }
}