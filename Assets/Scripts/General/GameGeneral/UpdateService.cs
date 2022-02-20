using UnityEngine;

namespace Assets.Scripts
{
    public class UpdateService : MonoBehaviour
    {
        public delegate void UpdatableMethod();
        public delegate void FixedUpdatableMethod();
        public event UpdatableMethod OnUpdate;
        public event FixedUpdatableMethod OnFixedUpdate;

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate() => OnFixedUpdate?.Invoke();
    }
}