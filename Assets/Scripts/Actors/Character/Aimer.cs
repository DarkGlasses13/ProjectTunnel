using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterControl))]
    public class Aimer : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float _aimSpeed;
        [SerializeField] private AimLine _aimLine;
        [SerializeField] private Flashlight _flashlight;

        private UpdateService _updateService;
        private Controls _controls;
        private CharacterControl _characterControl;
        private Vector3 _direction;
        private Vector3 _lastDirection;

        [Inject] private void Construct(UpdateService updateService, Controls controls)
        {
            _updateService = updateService;
            _controls = controls;
            _characterControl = GetComponent<CharacterControl>();
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Character.Attack.performed += CallbackContext => SetDirection();
            _controls.Character.Attack.canceled += CallbackContext => ResetDirection();
            _updateService.OnFixedUpdate += RotateFlashlight;
        }

        public void Aim()
        {
            _characterControl.DisableLookMotion();
            _characterControl.FastRotate(_lastDirection);
            _characterControl.EnableLookMotion();
        }

        private void RotateFlashlight()
        {
            if (_direction != Vector3.zero)
            {
                _flashlight.transform.rotation = Quaternion
                    .Lerp(_flashlight.transform.rotation, Quaternion.LookRotation(_direction), _aimSpeed * Time.fixedDeltaTime);
                return;
            }

            _flashlight.transform.localRotation = Quaternion
                .Lerp(_flashlight.transform.localRotation, Quaternion.identity, _aimSpeed * Time.fixedDeltaTime);
        }

        private void SetDirection()
        {
            float directionX = _controls.Character.Attack.ReadValue<Vector2>().x;
            float directionY = _controls.Character.Attack.ReadValue<Vector2>().y;
            _direction = new Vector3(directionX, 0, directionY);
        }

        private void ResetDirection()
        {
            _lastDirection = _direction;
            _direction = Vector3.zero;
        }

        private void OnDisable()
        {
            _controls.Disable();
            _updateService.OnFixedUpdate -= RotateFlashlight;
        }
    }
}
