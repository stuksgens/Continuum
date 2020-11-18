using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.Dependencies.CSharp
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Enum", menuName = "Life and Style Media/CSharp/Enum", order = 0)]
    public sealed class EnumAsset : TypeAsset
    {
        [SerializeField]
        public List<EnumItem> items = new List<EnumItem>();
    }
}