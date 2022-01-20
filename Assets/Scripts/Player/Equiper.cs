using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator), typeof(ControlableAttacker), typeof(ControlableAimer))]
    public class Equiper : MonoBehaviour
    {
        [SerializeField] private EquipmentSet _set;
        [SerializeField] private Transform _hand;

        private ControlableAttacker _attacker;
        private ControlableAimer _aimer;

        public Weapon EquipedWeapon { get; private set; }

        private void Awake()
        {
            _attacker = GetComponent<ControlableAttacker>();
            _aimer = GetComponent<ControlableAimer>();
        }

        private void Start()
        {
            Equip();
        }

        private void Equip()
        {
            EquipedWeapon = _set.Weapon;
            _attacker.SetAttack(EquipedWeapon);
            Instantiate(EquipedWeapon.Vew.gameObject, _hand);

            switch (EquipedWeapon.AttackType)
            {
                case AttackType.Single:
                    Attack.OnAttack.AddListener(_aimer.SingleLook);
                    break;
                case AttackType.Continuous:
                    Attack.OnAttack.AddListener(_aimer.ContinuousLook);
                    break;
            }
        }
    }
}