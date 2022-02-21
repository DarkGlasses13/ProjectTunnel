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

        [Inject] private void Construct(Controls controls, UpdateService updateCacher)
        {
            _controls = controls;
            _characterController = GetComponent<CharacterController>();
            _updateCacher = updateCacher;
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Character.Motion.performed += callbackContext => SetMotion();
            _controls.Character.Motion.canceled += callbackContext => ResetMotion();
            _updateCacher.OnFixedUpdate += Move;
            EnableLookMotion();
        }

        public void EnableLookMotion() => OnMove += LookMotion;

        private void LookMotion()
        {
            Quaternion lookDirection = Quaternion.LookRotation(_motion);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, _rotationSpeed * Time.fixedDeltaTime);
        }

        public void Look(Vector3 direction) => transform.LookAt(direction);

        private void Move()
        {
            if (_motion != Vector3.zero)
            {
                _characterController.Move(_motion * Time.fixedDeltaTime);
                OnMove.Invoke();
            }
        }

        private void SetMotion()
        {
            float motionX = _controls.Character.Motion.ReadValue<Vector2>().x;
            float motionY = _controls.Character.Motion.ReadValue<Vector2>().y;
            _motion = new Vector3(motionX, 0, motionY) * _moveSpeed;
        }

        private void ResetMotion() => _motion = Vector3.zero;

        public void DisableLookMotion() => OnMove -= LookMotion;

        private void OnDisable()
        {
            _controls.Disable();
            _updateCacher.OnFixedUpdate -= Move;
            DisableLookMotion();
        }
    }
}