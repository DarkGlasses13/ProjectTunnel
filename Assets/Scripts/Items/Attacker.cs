using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Attacker : MonoBehaviour
    {
        private IWeaponAttackScheme _attackScheme;

        public Controls Controls { get; private set; }
        public CoroutineService CoroutineService { get; private set; }

        public void SetAttackScheme(IWeaponAttackScheme attackScheme)
        {
            _attackScheme?.Cancel(this);
            _attackScheme = attackScheme;
            _attackScheme.Apply(this);
        }

        public void SetCoroutineService(CoroutineService coroutineService) => CoroutineService = coroutineService;

        public void SetControls(Controls controls) => Controls = controls;
    }
}