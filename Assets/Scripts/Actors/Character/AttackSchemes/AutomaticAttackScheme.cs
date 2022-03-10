using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AutomaticAttackScheme : FirearmAttackSceme<Automatic>, IWeaponAttackScheme
    {
        private Coroutine _automaticRoutine;
        private const float AttackDelay = 0.5f;

        public AutomaticAttackScheme(Automatic weaponData) : base(weaponData) { }

        void IWeaponAttackScheme.Apply(Attacker attacker)
        {
            _attacker = attacker;
            _attacker.Controls.Character.Aim.started += callbackContext => StartAttacking();
            _attacker.Controls.Character.Aim.canceled += callbackContext => StopAttacking();
            _attacker.BulletDealer.InitPool(_weaponData.Bullet, attacker.transform);
        }

        public void Attack()
        {
            _attacker.BulletDealer.GetBullet();
        }

        private void StartAttacking() => _automaticRoutine = _attacker.CoroutineService.StartRoutine(AutomaticRoutine());

        private void StopAttacking()
        {
            _attacker.CoroutineService.StopRoutine(_automaticRoutine);
            _attacker.UpdateService.OnFixedUpdate -= _attacker.CharacterControl.Rotate;
            _attacker.CharacterControl.EnableLookMotion();
        }

        private IEnumerator AutomaticRoutine()
        {
            yield return new WaitForSeconds(AttackDelay);
            _attacker.CharacterControl.DisableLookMotion();
            _attacker.UpdateService.OnFixedUpdate += _attacker.CharacterControl.Rotate;

            while (true)
            {
                Attack();
                yield return new WaitForSeconds(_weaponData.FireRate);
            }
        }

        void IWeaponAttackScheme.Cancel()
        {
            _attacker.Controls.Character.Aim.started -= callbackContext => StartAttacking();
            _attacker.Controls.Character.Aim.canceled -= callbackContext => StopAttacking();
        }
    }
}