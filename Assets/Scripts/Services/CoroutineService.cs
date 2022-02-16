using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class CoroutineService : MonoBehaviour
    {
        public Coroutine StartRoutine(IEnumerator enumerator) => StartCoroutine(enumerator);

        public void StopRoutine(Coroutine routine) => StopCoroutine(routine);
    }
}