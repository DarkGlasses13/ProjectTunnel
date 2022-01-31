using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Camera", fileName = "New Camera Config")]
    public class PlayerCameraConfig : Config
    {
        [SerializeField] [Range(1, 10)] private int _moveSpeed;

        public int MoveSpeed => _moveSpeed;
    }
}