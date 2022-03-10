using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class AimLine : MonoBehaviour
    {
        public LineRenderer Renderer { get; private set; }

        private void OnEnable() => Renderer = GetComponent<LineRenderer>();
    }
}
