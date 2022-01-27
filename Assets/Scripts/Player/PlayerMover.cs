using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController), typeof(Animator))]
    public class PlayerMover : MonoBehaviour
    {
        public static UnityEvent OnMove = new UnityEvent();

        [SerializeField] [Range(1, 10)] private int _moveSpeed;

        private Controls _controls;
        private CharacterController _controller;
        private Animator _animator;

        public Vector3 Motion { get; private set; }

        private void Awake()
        {
            _controls = new Controls();
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Player.Motion.performed += callbackContext => SetMotion(callbackContext);
            _controls.Player.Motion.canceled += callbackContext => ResetMotion();
        }

        private void FixedUpdate()
        {
            if (Motion != Vector3.zero)
            {
                float velocityX = Vector3.Dot(Motion, transform.forward);
                float velocityY = Vector3.Dot(Motion, transform.right);

                _controller.Move(Motion * _moveSpeed * Time.fixedDeltaTime);
                _animator.SetFloat(AnimationService.Parameters.MotionX, velocityX);
                _animator.SetFloat(AnimationService.Parameters.MotionY, velocityY);
                OnMove.Invoke();
            }
        }

        private void SetMotion(InputAction.CallbackContext callbackContext)
        {
            Motion = new Vector3(callbackContext.ReadValue<Vector2>().x, 0, callbackContext.ReadValue<Vector2>().y);
        }

        private void ResetMotion()
        {
            Motion = Vector3.zero;
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}