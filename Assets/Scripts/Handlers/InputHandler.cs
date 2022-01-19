using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        public static UnityEvent OnAimInputDown = new UnityEvent();
        public static UnityEvent OnAimInput = new UnityEvent();
        public static UnityEvent OnAimInputUp = new UnityEvent();

        [SerializeField] private InputType _type;
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _aimJoystick;

        private Camera _camera;
        private Transform _player;

        public static Vector2 MoveInput { get; private set; }
        public static Vector2 AimInput { get; private set; }
        public static Vector2 LastAimInput { get; private set; }

        private void Awake()
        {
            _camera = Camera.main;
            _player = _camera.GetComponent<CameraTracker>().Target;
            OnAimInputUp.AddListener(SetLastMouseDirection);
        }

        private void Update()
        {
            switch (_type)
            {
                case InputType.MouseAndKeyboard:
                    MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    AimInput = GetMouseDirection();
                    if (Input.GetMouseButtonDown(0)) { OnAimInputDown.Invoke(); }
                    if (Input.GetMouseButton(0)) { OnAimInput.Invoke(); }
                    if (Input.GetMouseButtonUp(0)) { OnAimInputUp.Invoke(); }
                    break;

                case InputType.Touchscreen:
                    MoveInput = _moveJoystick.Direction;
                    AimInput = _aimJoystick.Direction;
                    LastAimInput = _aimJoystick.LastDirection;
                    if (_aimJoystick.Down) { OnAimInputDown.Invoke(); }
                    if (_aimJoystick.Drag) { OnAimInput.Invoke(); }
                    if (_aimJoystick.Up) { OnAimInputUp.Invoke(); }
                    break;
            }
        }

        private void SetLastMouseDirection()
        {
            Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            {
                Vector3 direction = hitInfo.point - _player.position;
                LastAimInput = new Vector2(direction.x, direction.z).normalized;
            }
        }

        private Vector2 GetMouseDirection()
        {
            Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(0) && Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            {
                Vector3 direction = hitInfo.point -_player.position;
                return new Vector2(direction.x, direction.z).normalized;
            }

            return Vector2.zero;
        }
    }

    public enum InputType
    {
        MouseAndKeyboard,
        Touchscreen
    }
}