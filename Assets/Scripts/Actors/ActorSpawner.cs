using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ActorSpawner : MonoBehaviour
    {
        private CharacterFactory _characterFactory;

        [Inject] private void Construct(CharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        public void SpawnCharacter(Character prefab, CharacterConfig config, Transform parent, Vector3 position)
        {
            _characterFactory.Create(prefab, config, parent, position);
        }
    }
}