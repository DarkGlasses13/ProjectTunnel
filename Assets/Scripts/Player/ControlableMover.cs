using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController), typeof(Animator))]
    public class ControlableMover : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private int _moveSpeed;

        private CharacterController _controller;
        private Animator _animator;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector3 motion = new Vector3(InputHandler.MoveInput.x, 0, InputHandler.MoveInput.y);
            _animator.SetFloat(AnimationService.Parameters.MotionX, motion.x);
            _animator.SetFloat(AnimationService.Parameters.MotionY, motion.z);
            _controller.Move(motion * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}