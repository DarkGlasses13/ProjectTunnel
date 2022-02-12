using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [Header("WORLD")]
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Transform _worldParent;
        [SerializeField] private ItemDatabase _itemDatabase;

        [Header("CHARACTER")]
        [SerializeField] private CharacterConfig _characterConfig;

        [Header("PLAYER CAMERA")]
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
    }
}