using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TrailRenderer))]
    public class Bullet : MonoBehaviour
    {
        public delegate void OnHitMethod(Bullet bullet);
        public event OnHitMethod OnHit;

        [SerializeField] [Range(5, 100)] float _speed;
        [SerializeField] [Range(5, 50)] float _lifetime;

        private UpdateService _updateService;
        private TrailRenderer _trailRenderer;
        private float _currentLifetime;

        [Inject] private void Construct(UpdateService updateService)
        {
            _updateService = updateService;
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            _updateService.OnFixedUpdate += Accelerate;
            _updateService.OnUpdate += Live;
        }

        private void ResetLifetime() => _currentLifetime = default;

        private void Live()
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= _lifetime) Hit();
        }

        private void Accelerate() => transform.position += Vector3.forward * _speed * Time.fixedDeltaTime;

        public void ClearTrail() => _trailRenderer.Clear();

        private void Hit() => OnHit.Invoke(this);

        private void OnTriggerEnter(Collider other) => Hit();

        private void OnDisable()
        {
            _updateService.OnFixedUpdate -= Accelerate;
            _updateService.OnUpdate -= Live;
            ResetLifetime();
        }
    }
}