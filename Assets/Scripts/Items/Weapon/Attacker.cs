using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Attacker : MonoBehaviour
    {
        private IWeaponAttackScheme _attackScheme;

        public Controls Controls { get; private set; }
        public UpdateService UpdateService { get; private set; }
        public CoroutineService CoroutineService { get; private set; }
        public BulletDealer BulletDealer { get; private set; }
        public CharacterControl CharacterControl { get; private set; }

        [Inject] private void Construct(Controls controls, UpdateService updateService, CoroutineService coroutineService, BulletDealer bulletDealer)
        {
            Controls = controls;
            UpdateService = updateService;
            CoroutineService = coroutineService;
            BulletDealer = bulletDealer;
            CharacterControl = GetComponentInParent<CharacterControl>();
        }

        public void SetAttackScheme(IWeaponAttackScheme attackScheme)
        {
            _attackScheme?.Cancel();
            _attackScheme = attackScheme;
            _attackScheme?.Apply(this);
        }

        private void OnDisable() => _attackScheme?.Cancel();
    }
}