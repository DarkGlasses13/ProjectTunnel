using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class FireArmVew : Vew
    {
        [SerializeField] private Transform _barrel;

        public Vector3 Barrel => _barrel.position;
    }
}