using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Equiper), typeof(Animator))]
    public class ControlableAttacker : MonoBehaviour
    {
        private Equiper _equiper;
        private Animator _animator;

        private void Awake()
        {
            _equiper = GetComponent<Equiper>();
            _animator = GetComponent<Animator>();
            InputHandler.OnAimInputUp.AddListener(Attack);
        }

        public void OverrideAttackAnimation(AnimatorOverrideController animatorOverrideController)
        {
            _animator.runtimeAnimatorController = animatorOverrideController;
        }

        private void Attack()
        {
            _animator.SetTrigger(AnimationService.States.Attack);
        }
    }
}