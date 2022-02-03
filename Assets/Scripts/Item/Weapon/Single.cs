using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/singleWeapon", fileName = "New Single Weapon")]
    public class Single : FireArm
    {
        public Single()
        {
            _weaponScheme = new SingleAttackScheme();
        }
    }
}
