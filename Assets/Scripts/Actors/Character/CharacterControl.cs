using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControl : MonoBehaviour
    {
        public event Action OnMove;
        public event Action OnRotate;

        [SerializeField] [Range(1, 10)] private float _moveSpeed;
        [SerializeField] [Range(1, 10)] private float _rotationSpeed;

        private UpdateService _updateCacher;
        private Controls _controls;
        private CharacterController _characterController;
        private Light _flashlight;
        private Vector3 _motion;
        private Vector3 _look;

        [Inject] private void Construct(Controls controls, UpdateService updateCacher)
        {
            _controls = controls;
            _updateCacher = updateCacher;
            Init();
        }
        void Init()
        {
            _characterController = GetComponent<CharacterController>();
            _flashlight = GetComponentInChildren<Light>();
        }
        private void OnEnable()
        {
            _controls.Enable();

            _controls.Character.Motion.performed += callbackContext => SetMotion();
            _controls.Character.Motion.canceled += callbackContext => ResetMotion();

            _controls.Character.Attack.started += callbackContext => EnableRotate();
            _controls.Character.Attack.performed += callbackContext => SetAngle();
            _controls.Character.Attack.canceled += callbackContext => DisableRotate();

            _updateCacher.OnFixedUpdate += Move;
            _updateCacher.OnFixedUpdate += Rotate;
            EnableLookMotion();
        }

        public void EnableLookMotion() => OnMove += LookMotion;
        public void EnableLookAttack() => OnRotate += LookToAttack;
        public void EnableLookRotation() => OnRotate += Turn;

        private void LookMotion()
        {
            Quaternion moveDirection = Quaternion.LookRotation(_motion);
            transform.rotation = Quaternion.Lerp(transform.rotation, moveDirection, _rotationSpeed * Time.fixedDeltaTime);
        }
        private void LookToAttack()
        {
            transform.rotation = Quaternion.LookRotation(_look);
        }

        void Turn()
        {
            Quaternion lookDirection = Quaternion.LookRotation(_look);
            _flashlight.transform.rotation = lookDirection;
        }

        public void Look(Vector3 direction) => transform.LookAt(direction);

        private void Move()
        {
            if (_motion != Vector3.zero)
            {
                _characterController.Move(_motion * Time.fixedDeltaTime);
                OnMove?.Invoke();
            }
        }
        void Rotate()
        {
            if (_look != Vector3.zero)
            {
                OnRotate?.Invoke();
            }
            _flashlight.transform.rotation = Quaternion.Lerp(_flashlight.transform.rotation, transform.rotation, _rotationSpeed * Time.fixedDeltaTime);
        }
        private void SetMotion()
        {
            float motionX = _controls.Character.Motion.ReadValue<Vector2>().x;
            float motionY = _controls.Character.Motion.ReadValue<Vector2>().y;
            _motion = new Vector3(motionX, 0, motionY) * _moveSpeed;
        }

        void SetAngle()
        {
            float angleX = _controls.Character.Attack.ReadValue<Vector2>().x;
            float angleY = _controls.Character.Attack.ReadValue<Vector2>().y;
            _look = new Vector3(angleX, 0, angleY);
        }

        private void ResetMotion() => _motion = Vector3.zero;
        public void EnableAttack()
        {
            EnableLookAttack();
            DisableLookMotion();
        }
        public void DisableAttack()
        {
            EnableLookMotion();
            DisableLookAttack();
            _look = Vector3.zero;
        }
        void EnableRotate()
        {
            EnableLookRotation();
        }
        void DisableRotate()
        {
            DisableLookRotation();
            StartCoroutine(AttackRotine());
        }
        private IEnumerator AttackRotine()
        {
            yield return new WaitForSeconds(0.2f);
            DisableAttack();
        }
        public void DisableLookMotion() => OnMove -= LookMotion;
        public void DisableLookAttack() => OnRotate -= LookToAttack;
        public void DisableLookRotation() => OnRotate -= Turn;

        private void OnDisable()
        {
            _controls.Disable();
            _updateCacher.OnFixedUpdate -= Move;
            _updateCacher.OnFixedUpdate -= Rotate;
            DisableLookMotion();
        }
    }
}