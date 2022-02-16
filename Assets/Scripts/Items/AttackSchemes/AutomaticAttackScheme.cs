using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AutomaticAttackScheme : IWeaponAttackScheme
    {
        private Automatic _weaponData;
        private CoroutineService _coroutineService;
        private Coroutine _automaticRoutine;
        private const float _attackDelay = 0.5f;

        public AutomaticAttackScheme(Automatic weaponData)
        {
            _weaponData = weaponData;
        }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            _coroutineService = attacker.CoroutineService;
            attacker.Controls.Character.Attack.started += callbackContext => StartAttacking();
            attacker.Controls.Character.Attack.canceled += callbackContext => StopAttacking();
        }

        public void Attack()
        {
            Debug.Log("Automatic Attack !");
        }

        private void StartAttacking() => _automaticRoutine = _coroutineService.StartRoutine(AutomaticRoutine());

        private void StopAttacking() => _coroutineService.StopRoutine(_automaticRoutine);

        private IEnumerator AutomaticRoutine()
        {
            yield return new WaitForSeconds(_attackDelay);

            while (true)
            {
                Attack();
                yield return new WaitForSeconds(_weaponData.FireRate);
            }
        }

        void IWeaponAttackScheme.Cancel(Attacker attacker)
        {
            attacker.Controls.Character.Attack.started -= callbackContext => StartAttacking();
            attacker.Controls.Character.Attack.canceled -= callbackContext => StopAttacking();
        }
    }
}