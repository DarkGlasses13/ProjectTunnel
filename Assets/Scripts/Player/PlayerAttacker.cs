using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAttacker : MonoBehaviour
    {
        public static UnityEvent OnAttack = new UnityEvent();

        [SerializeField] private Transform _bulletSpawnPosition;
        [SerializeField] private AttackType _attackType;

        private Animator _animator;
        private Coroutine _continuousAttack;
        private float _timeBetweenAttack;

        public Transform BulletSpawnPosition => _bulletSpawnPosition;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAttackType(AttackType attackType)
        {
            _attackType = attackType;
        }

        public void OverrideAttackAnimation(AnimatorOverrideController animatorOverrideController)
        {
            _animator.runtimeAnimatorController = animatorOverrideController;
        }

        private void Attack()
        {
            Debug.Log("Attack !");
        }
    }
}