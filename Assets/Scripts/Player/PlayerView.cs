using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerView : View
    {
        private CharacterController _characterController;

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void UpdateMotion(Vector3 updatedMotion)
        {
            _characterController.Move(updatedMotion);
        }
    }
}