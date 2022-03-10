using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SingleFireAttackScheme : FirearmAttackSceme<Single>, IWeaponAttackScheme
    {
        public SingleFireAttackScheme(Single weaponData) : base(weaponData) { }

        private CoroutineService _coroutineService;
        private Coroutine _automaticRoutine;

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            _coroutineService = attacker.CoroutineService;
            attacker.Controls.Character.Attack.canceled += callbackContext => StartAttacking();
            _bulletDealer = attacker.BulletDealer;
            _bulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
            _aimer = attacker.Aimer;
        }

        private void StartAttacking()
        {
            _automaticRoutine = _coroutineService.StartRoutine(AutomaticRoutine());
        }

        private void StopAttacking()
        {
            _coroutineService.StopRoutine(_automaticRoutine);
        }

        public void Attack()
        {
            GameObject.FindObjectOfType<Aimer>().Aim(); // УБРАТЬ ЭТОТ ПОЗОР !!!
            _bulletDealer.GetBullet();
        }

        private IEnumerator AutomaticRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            Attack();
            StopAttacking();
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.canceled -= callbackContext => Attack();
        }
    }
}