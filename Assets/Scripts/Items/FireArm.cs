using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FireArm : Weapon
    {
        [SerializeField] private int _capacity;

        private Queue<Bullet> _mag = new Queue<Bullet>();
    }
}