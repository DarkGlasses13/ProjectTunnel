using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/MeleeWeapon", fileName = "New Melee Weapon")]
    public class Melee : Weapon
    {
        public Melee()
        {
            _weaponScheme = new SingleAttackScheme();
        }
    }
}
