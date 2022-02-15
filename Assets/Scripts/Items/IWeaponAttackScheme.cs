using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IWeaponAttackScheme
    {
        public void Apply(Attacker attacker);

        public void Cancel(Attacker attacker);
    }
}