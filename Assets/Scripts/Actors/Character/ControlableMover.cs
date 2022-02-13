using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ControlableMover : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;

        private UpdateCacher _updateCacher;

        [Inject] public void Construct(UpdateCacher updateCacher)
        {
            _updateCacher = updateCacher;
            Debug.Log(_updateCacher);
        }
    }
}