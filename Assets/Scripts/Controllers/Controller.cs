using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Controller<M,V,C> : IController where M: Model<C> where V: Vew where C: Config
    {
        protected M _model;
        protected V _vew;

        public Controller(M model, V vew)
        {
            _model = model;
            _vew = vew;
        }
    }
}