using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Game", fileName = "New Game Config")]
    public class GameConfig : Config
    {
        [Header("Balance Settings")]
        [SerializeField] private GameDifficulty _difficulty;
    }

    public enum GameDifficulty
    {
        Easy,
        Normal,
        Hard
    }
}