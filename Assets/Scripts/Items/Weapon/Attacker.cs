using UnityEngine;
using System;
using System.Collections;
using Zenject;

namespace Assets.Scripts
{
    public delegate void CallBackAttack();
    public class Attacker : MonoBehaviour
    {
        public CallBackAttack attack;

        private IWeaponAttackScheme _attackScheme;

        public Controls Controls { get; private set; }
        public CoroutineService CoroutineService { get; private set; }
        public BulletDealer BulletDealer { get; private set; }

        [Inject] private void Construct(Controls controls, CoroutineService coroutineService, BulletDealer bulletDealer)
        {
            Controls = controls;
            CoroutineService = coroutineService;
            BulletDealer = bulletDealer;

            attack += GetComponentInParent<CharacterControl>().EnableAttack;
        }
        public void SetAttackScheme(IWeaponAttackScheme attackScheme)
        {
            _attackScheme?.Cancel(this);
            _attackScheme = attackScheme;
            _attackScheme?.Apply(this, attack);
        }
        private void OnDisable() => _attackScheme?.Cancel(this);
    }
}