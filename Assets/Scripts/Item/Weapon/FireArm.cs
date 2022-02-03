using UnityEngine;

namespace Assets.Scripts
{
    public abstract class FireArm : Weapon
    {
        [SerializeField] [Range(1, 100)] protected int _capacity;
        [SerializeField] [Range(0, 5)] protected int _reloaringTime;

        public int Capacity => _capacity;
        public int ReloaringTime => _reloaringTime;
    }
}
