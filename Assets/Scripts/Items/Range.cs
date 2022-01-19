using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Range", fileName = "New Range")]
    public class Range : FireArm
    {
        [SerializeField] [Range(20, 180)] private float _angleRange;
        [SerializeField] [Range(3, 10)] private int _buletsInShot;
    }
}