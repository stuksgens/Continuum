using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.Continuum.CSharp
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Enum", menuName = "Life and Style Media/CSharp/Enum", order = 0)]
    public sealed class EnumAsset : TypeAsset
    {
        [Tooltip("Selecting this will allow a custom index to be generated for each item. Each item must have a unique index!")]
        public bool index;
        [Space(4)]
        [SerializeField]
        public List<EnumItem> items = new List<EnumItem>();
    }
}