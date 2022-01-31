using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : Controller<PlayerModel, PlayerVew, PlayerConfig>
    {
        public PlayerController(PlayerModel model, PlayerVew vew) : base(model, vew) 
        {
            _vew.OnMotionInput += ChangeMotion;
            _model.OnMotionChanged += DisplayMotion;
        }

        private void DisplayMotion(Vector3 updatedMotion)
        {
            _vew.UpdateMotion(updatedMotion);
        }

        private void ChangeMotion(Vector2 motionInput)
        {
            Vector3 motion = new Vector3(motionInput.x, 0, motionInput.y);
            _model.SetNewMotion(motion * _model.MoveSpeed * Time.fixedDeltaTime);
        }

        ~PlayerController()
        {
            _vew.OnMotionInput -= ChangeMotion;
            _model.OnMotionChanged -= DisplayMotion;
        }
    }
}