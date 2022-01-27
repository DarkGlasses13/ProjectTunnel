using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Weapon/Fists", fileName = "New Fists")]
    public class Fists : Weapon
    {
        public Fists()
        {
            AttackType = AttackType.Continuous;
        }
    }
}