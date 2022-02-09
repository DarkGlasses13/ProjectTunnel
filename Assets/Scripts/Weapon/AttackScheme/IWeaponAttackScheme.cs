using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IWeaponAttackScheme
    {
        public void Init(Weapon weapon);
        public void Attack();
    }
}