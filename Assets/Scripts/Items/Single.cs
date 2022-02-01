using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Single Weapon", fileName = "New Single Weapon")]
    public class Single : Firearm
    {
        public Single()
        {
            _attackScheme = new SingleAttackScheme();
        }
    }
}