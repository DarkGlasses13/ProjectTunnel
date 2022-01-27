using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public static UnityEvent<Bullet> OnHit = new UnityEvent<Bullet>();

        [SerializeField] [Range(10, 20)] private float _speed;

        private float _destroyDistance = 50;
        private Vector3 _startPosition;

        private void OnEnable()
        {
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);

            if (Vector3.Distance(_startPosition, transform.position) >= _destroyDistance)
                Hit();
        }

        private void Hit()
        {
            gameObject.SetActive(false);
            OnHit.Invoke(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider.name);
            Hit();
        }
    }
}