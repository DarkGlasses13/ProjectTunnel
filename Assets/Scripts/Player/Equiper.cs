using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator), typeof(ControlableAttacker))]
    public class Equiper : MonoBehaviour
    {
        [SerializeField] private EquipmentSet _set;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Transform _hand;

        private Animator _animator;
        private ControlableAttacker _attacker;

        public Weapon Weapon => _weapon;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _attacker = GetComponent<ControlableAttacker>();
            Equip();
        }

        public void Set(EquipmentSet set)
        {
            _set = set;
        }

        private void Equip()
        {
            _weapon = _set.Weapon;
            Instantiate(_weapon.Vew, _hand);
            _attacker.OverrideAttackAnimation(_weapon.AnimatorOverrideController);
        }
    }
}