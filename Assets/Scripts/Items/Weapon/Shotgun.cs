using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun", fileName = "New Shotgun")]
    public class Shotgun : Firearm
    {
        public Shotgun()
        {
            _weaponScheme = new ShotAttackScheme();
        }
    }
}