using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Automatic", fileName = "New Automatic")]
    public class Automatic : FireArm
    {
        [SerializeField] [Range(1, 3)] private int _fireRate;
    }
}