using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Pool<T> where T : MonoBehaviour
    {
        private List<T> _pool;

        public T Prefab { get; private set; }
        public Transform Container { get; private set; }
        public Transform ActivationSpot { get; private set; }

        public Pool(T prefab, int size, Transform container, Transform activationSpot)
        {
            Prefab = prefab;
            Container = container;
            ActivationSpot = activationSpot;
            Init(size);
        }

        public void ActivateObject()
        {
            GetObject();
        }

        public bool HasObject(out T obj)
        {
            foreach (var o in _pool)
            {
                if (o.gameObject.activeInHierarchy == false)
                {
                    obj = o;
                    o.transform.position = ActivationSpot.position;
                    o.gameObject.SetActive(true);
                    return true;
                }
            }

            obj = null;
            return false;
        }

        public T GetObject()
        {
            if (HasObject(out var obj)) { return obj; }
            throw new System.Exception($"Out of size - {Prefab.gameObject.name} pool !");
        }

        private void Init(int size)
        {
            _pool = new List<T>();

            for (int i = 0; i < size; i++)
                CreateObject();
        }

        private T CreateObject(bool isActive = false)
        {
            var obj = Object.Instantiate(Prefab, Container);
            obj.gameObject.SetActive(isActive);
            _pool.Add(obj);
            return obj;
        }
    }
}