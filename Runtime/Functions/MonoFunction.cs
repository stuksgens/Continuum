using System;
using System.Collections;
using UnityEngine;

namespace Lasm.EbbnFlow
{
    [Serializable]
    public abstract class MonoFunction : MonoBehaviour, IFunction
    {
        public virtual bool isCoroutine => false;

        public virtual object Invoke(Flow flow) { return null; }

        public virtual IEnumerator Run(Flow flow)
        {
            Invoke(flow);
            yield break;
        }
    }
}