using System;
using UnityEngine;

namespace Lasm.EbbnFlow
{
    [Serializable]
    public abstract class ConditionalMonoFunction : MonoBehaviour, IFunction<bool>
    {
        public virtual bool Invoke(Flow flow) { return false; }
    }
}