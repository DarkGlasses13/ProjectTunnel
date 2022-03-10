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
        private Vector3 _direction;

        [Inject] private void Construct(UpdateService updateService, Controls controls)
        {
            _updateService = updateService;
            _controls = controls;
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Character.Aim.started += CallbackContext => EnableAimLine();
            _controls.Character.Aim.performed += CallbackContext => SetDirection();
            _controls.Character.Aim.canceled += CallbackContext => ResetDirection();
            _controls.Character.Aim.canceled += CallbackContext => DisableAimLine();
            _updateService.OnFixedUpdate += RotateFlashlight;
            _updateService.OnFixedUpdate += RotateAimLine;
        }

        private void RotateAimLine() => Rotate(_aimLine.transform);

        private void RotateFlashlight() => Rotate(_flashlight.transform);

        private void Rotate(Transform rotatableObject)
        {
            if (_direction != Vector3.zero)
            {
                rotatableObject.rotation = Quaternion
                    .Lerp(rotatableObject.rotation, Quaternion.LookRotation(_direction), _aimSpeed * Time.fixedDeltaTime);
                return;
            }

            rotatableObject.localRotation = Quaternion
                .Lerp(rotatableObject.localRotation, Quaternion.identity, _aimSpeed * Time.fixedDeltaTime);
        }

        private void EnableAimLine() => _aimLine.gameObject.SetActive(true);

        private void DisableAimLine() => _aimLine.gameObject.SetActive(false);

        private void SetDirection()
        {
            float directionX = _controls.Character.Aim.ReadValue<Vector2>().x;
            float directionY = _controls.Character.Aim.ReadValue<Vector2>().y;
            _direction = new Vector3(directionX, 0, directionY);
        }

        private void ResetDirection() => _direction = Vector3.zero;

        private void OnDisable()
        {
            _controls.Disable();
            _updateService.OnFixedUpdate -= RotateFlashlight;
            _updateService.OnFixedUpdate -= RotateAimLine;
        }
    }
}
