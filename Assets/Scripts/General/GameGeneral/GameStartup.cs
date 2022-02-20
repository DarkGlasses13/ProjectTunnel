using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [Header("CONFIGURATIONS")]
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;

        [Header("PARENTS")]
        [SerializeField] private Transform _mainParent;
        [SerializeField] private Transform _chunksParent;
        [SerializeField] private Transform _actorParent;

        [Header("SpawnPoints")]
        [SerializeField] private Transform _characterSpawnPoint;

        [Header("ACTOR PREFABS")]
        [SerializeField] private BulletDealer _bulletDealerPrefab;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Character _characterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;

        [Inject] private void Construct(BulletDealerFactory bulletDealerFactory, CharacterFactory characterFactory, PlayerCameraFactory playerCameraFactory)
        {
            bulletDealerFactory.Create(_bulletDealerPrefab, _bulletPrefab, _actorParent);
            Character character = characterFactory.Create(_characterPrefab, _characterConfig, _actorParent, _characterSpawnPoint.position);
            playerCameraFactory.Create(_playerCameraPrefab, _playerCameraConfig, _actorParent, character);
        }
    }
}