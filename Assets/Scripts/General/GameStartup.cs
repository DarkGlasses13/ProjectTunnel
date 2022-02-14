using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [Header("GENERAL")]
        [SerializeField] private ActorSpawner _actorSpawner;

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
        [SerializeField] private Character _characterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;

        private void Start()
        {
            _actorSpawner.SpawnCharacter(_characterPrefab, _characterConfig, _actorParent, _characterSpawnPoint.position);
        }
    }
}