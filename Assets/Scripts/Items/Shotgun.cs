using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Weapons/Shotgun", fileName = "New Shotgun")]
    public class Shotgun : Single
    {
        [SerializeField] [Range(20, 180)] private float _angleRange;
        [SerializeField] [Range(3, 10)] private int _buletsInShot;
    }
}