using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerView : View
    {
        public Action<Vector2> OnMotionInput;

        private Controls _controls;
        private CharacterController _characterController;
        private Vector2 _motionInput;

        private void OnEnable()
        {
            _controls = new Controls();
            _characterController = GetComponent<CharacterController>();
            _controls.Enable();
            _controls.Player.Motion.performed += callbackContext => SetMotionInput(callbackContext);
            _controls.Player.Motion.canceled += callbackContext => ResetMotionInput();
            GameStartup.OnFixedUpdate += CheckInput;
        }

        public void UpdateMotion(Vector3 updatedMotion)
        {
            _characterController.Move(updatedMotion);
        }

        private void CheckInput()
        {
            if (_motionInput != Vector2.zero)
                OnMotionInput?.Invoke(_motionInput);
        }

        private void SetMotionInput(InputAction.CallbackContext callbackContext) => _motionInput = callbackContext.ReadValue<Vector2>();


        private void ResetMotionInput() => _motionInput = Vector2.zero; 

        private void OnDisable()
        {
            _controls.Disable();
            GameStartup.OnFixedUpdate -= CheckInput;
        }
    }
}