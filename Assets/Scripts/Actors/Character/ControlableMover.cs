using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class ControlableMover : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;

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
        }

        private void Move()
        {
            if (_motion != Vector3.zero)
            {
                _characterController.Move(_motion * Time.fixedDeltaTime);
            }
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
            _updateCacher.OnFixedUpdate -= Move;
        }
    }
}