using UnityEngine;

namespace Assets.Scripts
{
    public abstract class View : MonoBehaviour, IView
    {
        protected IController _controller;

        public void SetController(IController controller)
        {
            _controller = controller;
        }
    }
}