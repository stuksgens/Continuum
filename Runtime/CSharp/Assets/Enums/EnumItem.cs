using System;
using UnityEngine;

namespace Lasm.Dependencies.CSharp
{
    [Serializable]
    public class EnumItem
    {
        [SerializeField]
        public int index;
        [SerializeField]
        public string name;
    }
}