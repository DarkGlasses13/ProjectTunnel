using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AutomaticAttackScheme : FirearmAttackSceme<Automatic>, IWeaponAttackScheme
    {
        private CoroutineService _coroutineService;
        private Coroutine _automaticRoutine;
        private CallBackAttack callBack;
        private const float _attackDelay = 0.5f;

        public AutomaticAttackScheme(Automatic weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker, CallBackAttack cb)
        {
            _coroutineService = attacker.CoroutineService;
            attacker.Controls.Character.Attack.started += callbackContext => StartAttacking();
            attacker.Controls.Character.Attack.canceled += callbackContext => StopAttacking();
            callBack = cb;
            _bulletDealer = attacker.BulletDealer;
            _bulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            _bulletDealer.GetBullet();
        }

        private void StartAttacking()
        {
            _automaticRoutine = _coroutineService.StartRoutine(AutomaticRoutine());
            callBack?.Invoke();
        }

        private void StopAttacking() 
        {
            _coroutineService.StopRoutine(_automaticRoutine);
        } 

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