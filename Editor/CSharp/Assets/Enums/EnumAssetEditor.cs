using Lasm.Dependencies.Humility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UEditor = UnityEditor.Editor;

namespace Lasm.Dependencies.CSharp.Editor
{
    [CustomEditor(typeof(EnumAsset))]
    public class EnumAssetEditor : UEditor
    {
        private ICodeGenerator generator;
        private bool refreshed;

        public override void OnInspectorGUI()
        {
            HUMEditor.Changed(() => { base.OnInspectorGUI(); }, () => { refreshed = false; });

            if (CSharpPreview.instance != null)
            {
                if (generator == null) generator = EnumAssetGenerator.GetDecorator(target as EnumAsset) as ICodeGenerator;
                CSharpPreview.instance.code = generator;
                if (!refreshed)
                {
                    CSharpPreview.instance.Refresh();
                    refreshed = true;
                }
            }
        }
    }
}