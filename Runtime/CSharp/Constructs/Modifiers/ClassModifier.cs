using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.CSharp
{
    /// <summary>
    /// A modifier that further changes or expands on the scope of a class.
    /// </summary>
    public enum ClassModifier
    {
        None,
        Abstract,
        Partial,
        Sealed,
        Static,
        StaticPartial
    }
}
