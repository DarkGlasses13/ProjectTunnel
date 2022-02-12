using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        public static UnityEvent OnStartGame = new UnityEvent();
        public static UnityEvent OnEscapeGame = new UnityEvent();

        private const int _hub = 1;
        private const int _game = 0;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(_game);
            OnStartGame.Invoke();
        }

        public void EscapeGame()
        {
            SceneManager.LoadScene(_hub);
            OnEscapeGame.Invoke();
        }
    }
}