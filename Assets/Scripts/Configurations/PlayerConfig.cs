using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Player", fileName = "New Player Config")]
    public class PlayerConfig : Config
    {
        [SerializeField] [Range(1, 10)] private int _moveSpeed;
        [SerializeField] [Range(5, 20)] private int _rotationSpeed;

        public int MoveSpeed => _moveSpeed;
        public int RotationSpeed => _rotationSpeed;
    }
}