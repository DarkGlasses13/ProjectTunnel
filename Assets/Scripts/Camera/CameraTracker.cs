using UnityEngine;

namespace Assets.Scripts
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] [Range(0, 10)] private int _trackingSpeed;

        private Vector3 _offset;

        public Transform Target => _target;

        private void Start()
        {
            _offset = GetOffset();
        }

        private void FixedUpdate()
        {
            Track(_offset, _target.position, _trackingSpeed);
        }

        private Vector3 GetOffset()
        {
            return transform.position;
        }

        private void Track(Vector3 offset, Vector3 target, float trackingSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, target + offset, trackingSpeed * Time.fixedDeltaTime);
        }
    }
}