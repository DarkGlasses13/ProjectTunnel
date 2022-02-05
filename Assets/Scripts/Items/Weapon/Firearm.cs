using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Firearm : Weapon
    {
        [SerializeField] [Range(1, 100)] protected int _capacity;
        [SerializeField] [Range(0, 5)] int _reloaringTime;

        public int Capacity => _capacity;
        public int ReloadingTime => _reloaringTime;
    }
}