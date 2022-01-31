using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private int _moveSpeed;
        [SerializeField] private Transform _player;

        private Vector3 _offset;

        private void OnEnable()
        {
            GameStartup.OnFixedUpdate += Track;
            _offset = transform.position;
        }

        private void Track()
        {
            transform.position = Vector3.Lerp(transform.position, _player.position + _offset, _moveSpeed * Time.fixedDeltaTime);
        }

        private void OnDisable()
        {
            GameStartup.OnFixedUpdate -= Track;
        }
    }
}