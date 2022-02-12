using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        public static UnityEvent OnEnterTunnel = new UnityEvent();
        public static UnityEvent OnEscapeTunnel = new UnityEvent();

        private const int _hubSceneIndex = 0;
        private const int _gameSceneIndex = 1;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void EnterTunnel()
        {
            SceneManager.LoadScene(_gameSceneIndex);
            OnEnterTunnel.Invoke();
        }

        public void EscapeTunnel()
        {
            SceneManager.LoadScene(_hubSceneIndex);
            OnEscapeTunnel.Invoke();
        }
    }
}