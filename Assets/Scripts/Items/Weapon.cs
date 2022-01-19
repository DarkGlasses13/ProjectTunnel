using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : Equipment
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected AnimatorOverrideController _animationOverrideController;
        [SerializeField] protected AnimationClip _animation;

        public int Damage => _damage;
        public AnimatorOverrideController AnimatorOverrideController => _animationOverrideController;
        public AnimationClip Animation => _animation;
    }
}