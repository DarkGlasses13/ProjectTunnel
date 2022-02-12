using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerController : Controller<PlayerModel, PlayerView, PlayerConfig>
    {
        public static UnityEvent OnEnablePlayerControl = new UnityEvent();
        public static UnityEvent OnDisablePlayerControl = new UnityEvent();

        private Controls _controls;
        private Vector2 _motionInput;

        public PlayerController(PlayerModel model, PlayerView view) : base(model, view) 
        {
            _controls = new Controls();
            _controls.Enable();
            EnableControl();
            _model.OnMotionChanged += _view.DisplayMotion;
        }
        
        private void ReadMotionInput(InputAction.CallbackContext context) => _motionInput = context.ReadValue<Vector2>();

        private void ResetMotionInput() => _motionInput = Vector2.zero;

        private void ChangeMotion()
        {
            if (_motionInput != Vector2.zero)
            {
                Vector3 motion = new Vector3(_motionInput.x, 0, _motionInput.y);
                _model.SetNewMotion(motion * _model.MoveSpeed * Time.fixedDeltaTime);
            } 
        }

        public void EnableControl()
        {
            Debug.Log("Player Control Was Enabled");
            _controls.Enable();
            _controls.Player.Motion.performed += context => ReadMotionInput(context);
            _controls.Player.Motion.canceled += context => ResetMotionInput();
            GameStartup.OnFixedUpdate += ChangeMotion;
            OnEnablePlayerControl.Invoke();
        }

        public void DisableControl()
        {
            Debug.Log("Player Control Was Disabled");
            _controls.Disable();
            _model.OnMotionChanged -= _view.DisplayMotion;
            GameStartup.OnFixedUpdate -= ChangeMotion;
            OnDisablePlayerControl.Invoke();
        }

        ~PlayerController()
        {
            _controls.Disable();
        }
    }
}