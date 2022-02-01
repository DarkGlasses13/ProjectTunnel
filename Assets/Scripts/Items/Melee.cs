﻿using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Item/Weapon/Melee Weapon", fileName = "New Melee Weapon")]
    public class Melee : Weapon
    {
        public Melee()
        {
            _attackScheme = new SingleAttackScheme();
        }
    }
}