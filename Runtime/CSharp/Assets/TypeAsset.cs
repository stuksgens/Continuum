using System;
using UnityEngine;

namespace Lasm.Dependencies.CSharp
{
    [Serializable]
    public abstract class TypeAsset : ScriptableObject, ITypeDeclaration
    {
        #region Declaration

        [SerializeField]
        private string _title;
        public virtual string title { get => _title; set => _title = value; }

        [SerializeField]
        private string _namespace;
        public virtual string @namespace { get => _namespace; set => _namespace = value; }

        #endregion
    }
}