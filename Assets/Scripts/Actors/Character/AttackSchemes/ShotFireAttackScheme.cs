using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class ShotFireAttackScheme : FirearmAttackSceme<Shotgun>, IWeaponAttackScheme
    {
        public ShotFireAttackScheme(Shotgun weaponData) : base(weaponData) { }

        private CallBackAttack callBack;
        private CoroutineService _coroutineService;
        private Coroutine _automaticRoutine;
        void IWeaponAttackScheme.Apply(Attacker attacker, CallBackAttack cb)
        {
            _coroutineService = attacker.CoroutineService;
            attacker.Controls.Character.Attack.canceled += callbackContext => StartAttacking();
            callBack = cb;
            _bulletDealer = attacker.BulletDealer;
            _bulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
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
        public void Attack()
        {
            float delta = _weaponData.SpreadAngle / _weaponData.BulletsPerShot;
            float correctiveAngle = delta / 2;

            float startAngle = -_weaponData.SpreadAngle / 2;
            startAngle += correctiveAngle;

            for (int i = 0; i < _weaponData.BulletsPerShot; i++)
            {
                _bulletDealer.GetBullet().transform.Rotate(0, startAngle, 0);
                startAngle += delta;
            }
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