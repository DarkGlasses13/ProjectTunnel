using System;

namespace Assets.Scripts
{
    public interface IWeaponAttackScheme
    {
        public void Apply(Attacker attacker, CallBackAttack cb);
        public void Attack();
        public void Cancel(Attacker attacker);
    }
}