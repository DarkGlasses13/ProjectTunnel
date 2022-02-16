using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Range(5, 20)] private int _speed;

        private UpdateService _updateService;
        private BulletDealer _bulletDealer;

        private void OnEnable()
        {
            //_updateService.OnFixedUpdate += Accelerate;
        }

        private void Accelerate() => transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Collide with {collision.collider.name}");
        }

        private void OnDisable()
        {
            //_updateService.OnFixedUpdate -= Accelerate;
        }
    }
}