using UnityEngine;

namespace Assets.Scripts
{
    public class ControlableAimer : MonoBehaviour
    {
        [SerializeField] [Range(5, 20)] private int _rotationSpeed;
        [SerializeField] [Range(10, 50)] private int _aimRotationSpeed;
        [SerializeField] private LineRenderer _aimLine;
        [SerializeField] [Range(1, 10)] private int _aimLineLenght;

        private void Awake()
        {
            InputHandler.OnAimInputDown.AddListener(ShowAimLine);
            InputHandler.OnAimInput.AddListener(Aim);
            InputHandler.OnAimInputUp.AddListener(HideAimLine);
        }

        private void Update()
        {
            if (Attack.IsAttack == false)
                LookMotion();
        }

        private void Aim()
        {
            float rayOffsetY = 0.1f;
            Vector3 rayOrigin = new Vector3(transform.position.x, rayOffsetY, transform.position.z);
            Vector3 rayDirection = new Vector3(InputHandler.AimInput.x, 0, InputHandler.AimInput.y);
            Ray ray = new Ray(rayOrigin, rayDirection);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _aimLineLenght))
            {
                _aimLine.SetPosition(0, ray.origin);
                _aimLine.SetPosition(1, hitInfo.point);
            }
            else
            {
                _aimLine.SetPosition(0, ray.origin);
                _aimLine.SetPosition(1, (ray.origin + ray.direction * _aimLineLenght));
            }
        }

        private void ShowAimLine()
        {
            _aimLine.gameObject.SetActive(true);
        }

        private void HideAimLine()
        {
            _aimLine.gameObject.SetActive(false);
        }

        public void ContinuousLook()
        {
            Look(InputHandler.AimInput, _aimRotationSpeed);
        }

        public void SingleLook()
        {
            Look(InputHandler.LastAimInput, _aimRotationSpeed);
        }

        private void LookMotion()
        {
            Look(InputHandler.MoveInput, _rotationSpeed);
        }

        private void Look(Vector2 input, int rotationSpeed)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y);

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}