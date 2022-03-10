using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Light))]
    public class Flashlight : MonoBehaviour 
    {
        public Light Light { get; private set; }

        private void OnEnable() => Light = GetComponent<Light>();
    }
}
