using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Automatic Weapon", fileName = "New Automatic Weapon")]
    public class Automatic : Firearm
    {
        public Automatic()
        {
            _weaponScheme = new ContinuousAttackScheme();
        }
    }
}