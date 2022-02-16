using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float _duration;

        private UpdateService _updateCacher;
        private Transform _character;

        [Inject] private void Construct(UpdateService updateCacher)
        {
            _updateCacher = updateCacher;
        }

        private void OnEnable()
        {
            _updateCacher.OnFixedUpdate += FollowCharacter;
        }

        private void FollowCharacter()
        {
            Vector3 targetPosition = new Vector3(transform.position.x, _character.transform.position.y, _character.transform.position.z);

            if (transform.position != targetPosition)
                transform.position = Vector3.Lerp(transform.position, targetPosition, _duration * Time.fixedDeltaTime);
        }

        public void SetCharacter(Character character) => _character = character.transform;

        private void OnDisable()
        {
            _updateCacher.OnFixedUpdate -= FollowCharacter;
        }
    }
}