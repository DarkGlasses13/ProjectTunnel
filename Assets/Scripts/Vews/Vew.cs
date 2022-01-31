using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Vew : MonoBehaviour
    {
        protected IController _controller;

        public void SetController(IController controller)
        {
            _controller = controller;
        }
    }
}