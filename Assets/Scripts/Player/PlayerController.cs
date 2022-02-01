using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : Controller<PlayerModel, PlayerView, PlayerConfig>
    {
        public PlayerController(PlayerModel model, PlayerView view) : base(model, view) 
        {
            _view.OnMotionInput += ChangeMotion;
            _model.OnMotionChanged += DisplayMotion;
        }

        private void DisplayMotion(Vector3 updatedMotion)
        {
            _view.UpdateMotion(updatedMotion);
        }

        private void ChangeMotion(Vector2 motionInput)
        {
            Vector3 motion = new Vector3(motionInput.x, 0, motionInput.y);
            _model.SetNewMotion(motion * _model.MoveSpeed * Time.fixedDeltaTime);
        }

        ~PlayerController()
        {
            _view.OnMotionInput -= ChangeMotion;
            _model.OnMotionChanged -= DisplayMotion;
        }
    }
}