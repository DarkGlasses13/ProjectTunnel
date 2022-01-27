using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] [Range(5, 20)] private int _rotationSpeed;

        public void Look(Vector3 direction, float speed, float timeDelta)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * timeDelta);
        }
    }
}