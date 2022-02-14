using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class CharacterFactory : PlaceholderFactory<Character, CharacterConfig, Transform, Vector3,  Character>
    {

    }
}