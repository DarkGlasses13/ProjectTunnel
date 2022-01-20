using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Range(10, 20)] private float _speed;

        private void FixedUpdate()
        {
            
        }
    }
}