using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ReidStartup : MonoBehaviour
    {
        [Header("CONFIGURATIONS")]
        [SerializeField] private ReidConfig _reidConfig;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;

        [Header("PARENTS")]
        [SerializeField] private Transform _mainParent;
        [SerializeField] private Transform _chunksParent;
        [SerializeField] private Transform _actorParent;

        [Header("SpawnPoints")]
        [SerializeField] private Transform _characterSpawnPoint;

        [Header("ACTOR PREFABS")]
        [SerializeField] private BulletDealer _bulletDealer;
        [SerializeField] private Character _characterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;

        private BulletDeallerFactory _bulletDealerFactory;
        private CharacterFactory _characterFactory;
        private PlayerCameraFactory _playerCameraFactory;

        private Character _character;

        [Inject] private void Construct(BulletDeallerFactory bulletDeallerFactory, CharacterFactory characterFactory, PlayerCameraFactory playerCameraFactory)
        {
            _bulletDealerFactory = bulletDeallerFactory;
            _characterFactory = characterFactory;
            _playerCameraFactory = playerCameraFactory;
        }

        private void Start()
        {
            _bulletDealerFactory.Create(_bulletDealer, _actorParent);
            SpawnCharacter();
            SpawnPlayerCamera();
        }

        private void SpawnCharacter()
        {
            _character = _characterFactory.Create(_characterPrefab, _characterConfig, _actorParent, _characterSpawnPoint.position);
        }

        private void SpawnPlayerCamera()
        {
            _playerCameraFactory.Create(_playerCameraPrefab, _playerCameraConfig, _actorParent, _character);
        }
    }
}