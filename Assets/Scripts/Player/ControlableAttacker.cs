using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class ControlableAttacker : MonoBehaviour
    {
        private Animator _animator;
        private Weapon _weapon;
        private AttackType _attackType;
        private Coroutine _continuousAttack;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAttack(Weapon weapon)
        {
            _weapon = weapon;
            _attackType = _weapon.AttackType;
            _animator.runtimeAnimatorController = _weapon.AttackOverride;

            switch (_attackType)
            {
                case AttackType.Single:
                    InputHandler.OnAimInputUp.AddListener(Attack);
                    break;

                case AttackType.Continuous:
                    InputHandler.OnAimInputDown.AddListener(StartContinuousAttack);
                    InputHandler.OnAimInputUp.AddListener(EndContinuousAttack);
                    break;
            }
        }

        public void OverrideAttackAnimation(AnimatorOverrideController animatorOverrideController)
        {
            _animator.runtimeAnimatorController = animatorOverrideController;
        }

        private void StartContinuousAttack()
        {
            _continuousAttack = StartCoroutine(ContinuousAttack());
        }

        private void EndContinuousAttack()
        {
            StopCoroutine(_continuousAttack);
        }

        private IEnumerator ContinuousAttack()
        {
            Continuous weapon = _weapon as Continuous;

            yield return new WaitForSeconds(1);

            while (true)
            {
                Attack();
                yield return new WaitForSeconds(weapon.TimeBetweenAttack);
            }
        }

        private void Attack()
        {
            _animator.SetTrigger(AnimationService.States.Attack);
        }
    }
}