using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Controller<M,V,C> : IController where M: Model<C> where V: View where C: Config
    {
        protected M _model;
        protected V _view;

        public Controller(M model, V view)
        {
            _model = model;
            _view = view;
            _view.SetController(this);
        }
    }
}