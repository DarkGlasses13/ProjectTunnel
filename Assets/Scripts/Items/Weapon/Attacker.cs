using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Attacker : MonoBehaviour
    {
        private IWeaponAttackScheme _attackScheme;

        public Controls Controls { get; private set; }
        public CoroutineService CoroutineService { get; private set; }
        public BulletDealer BulletDealer { get; private set; }
        public Aimer Aimer { get; private set; }

        [Inject] private void Construct(Controls controls, CoroutineService coroutineService, BulletDealer bulletDealer)
        {
            Controls = controls;
            CoroutineService = coroutineService;
            BulletDealer = bulletDealer;
        }

        public void SetAttackScheme(IWeaponAttackScheme attackScheme)
        {
            _attackScheme?.Cancel(this);
            _attackScheme = attackScheme;
            _attackScheme?.Apply(this);
        }

        private void OnDisable() => _attackScheme?.Cancel(this);
    }
}