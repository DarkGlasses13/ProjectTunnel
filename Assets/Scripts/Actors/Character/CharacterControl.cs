using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControl : MonoBehaviour
    {
        public event Action OnMove;

        [SerializeField] [Range(1, 10)] private float _moveSpeed;
        [SerializeField] [Range(1, 10)] private float _rotationSpeed;

        private UpdateService _updateCacher;
        private Controls _controls;
        private CharacterController _characterController;
        private Vector3 _motion;
        private Quaternion _rotation;
        private Quaternion _lastRotation;

        [Inject] private void Construct(Controls controls, UpdateService updateCacher)
        {
            _controls = controls;
            _updateCacher = updateCacher;
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _controls.Enable();

            _controls.Character.Motion.performed += callbackContext => SetMotion();
            _controls.Character.Aim.performed += callbackContext => SetRotation();
            _controls.Character.Motion.canceled += callbackContext => ResetMotion();
            _controls.Character.Aim.canceled += callbackContext => ResetRotation();

            EnableMove();
            EnableLookMotion();
        }

        public void EnableLookMotion() => _updateCacher.OnFixedUpdate += LookMotion;

        public void EnableMove() => _updateCacher.OnFixedUpdate += Move;

        public void DisableMove() => _updateCacher.OnFixedUpdate -= Move;

        public void DisableLookMotion() => _updateCacher.OnFixedUpdate -= LookMotion;

        private void LookMotion() => Rotate(_motion, _rotationSpeed);

        public void RotateFast() => transform.rotation = _lastRotation;

        public void Rotate(Vector3 direction, float rotationSpeed)
        {
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion
                    .Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.fixedDeltaTime);
            }
        }

        public void Rotate()
        {
            transform.rotation = Quaternion
                    .Lerp(transform.rotation, _rotation, _rotationSpeed * Time.fixedDeltaTime);
        }

        private void Move()
        {
            if (_motion != Vector3.zero)
            {
                _characterController.Move(_motion * Time.fixedDeltaTime);
                OnMove?.Invoke();
            }
        }

        private void SetRotation()
        {
            float rotationX = _controls.Character.Aim.ReadValue<Vector2>().x;
            float rotationY = _controls.Character.Aim.ReadValue<Vector2>().y;
            _rotation = Quaternion.LookRotation(new Vector3(rotationX, 0, rotationY));
        }

        private void ResetRotation()
        {
            _lastRotation = _rotation;
            _rotation = Quaternion.identity;
        }

        private void SetMotion()
        {
            float motionX = _controls.Character.Motion.ReadValue<Vector2>().x;
            float motionY = _controls.Character.Motion.ReadValue<Vector2>().y;
            _motion = new Vector3(motionX, 0, motionY) * _moveSpeed;
        }

        private void ResetMotion() => _motion = Vector3.zero;

        private void OnDisable()
        {
            _controls.Disable();
            DisableMove();
            DisableLookMotion();
        }
    }
}