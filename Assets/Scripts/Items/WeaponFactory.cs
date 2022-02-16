using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class WeaponFactory : PlaceholderFactory<EquipmentView, Transform, IWeaponAttackScheme, Attacker>
    {
        
    }
}