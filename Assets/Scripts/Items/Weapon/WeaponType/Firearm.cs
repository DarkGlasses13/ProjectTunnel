using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Firearm : Weapon
    {
        [SerializeField] [Range(1, 100)] protected int _capacity;
        [SerializeField] [Range(0, 5)] float _reloaringTime;

        public int Capacity => _capacity;
        public float ReloadingTime => _reloaringTime;
    }
}