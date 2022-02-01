using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public abstract class Model<C> : IModel where C: Config
    {
        public Model(C config) { SetConfig(config); }

        protected abstract void SetConfig(C config);
    }
}