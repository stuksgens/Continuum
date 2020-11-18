using UnityEngine;
using Lasm.Dependencies.Humility;
using Lasm.Dependencies.CSharp;
using System;
using UnityEditor;

namespace Lasm.Dependencies.Editor
{
    public sealed class CompilationTool : DependencyTool
    {
        public override string DisplayName => "Compilation";

        public CompilationTool() : base() { }

        public override void OnGUI()
        {
            if (GUILayout.Button("Generate Scripts"))
            {
                var compilers = typeof(CompilationQuery).Get().Derived();

                for (int i = 0; i < compilers.Length; i++)
                {
                    var query = Activator.CreateInstance(compilers[i]) as CompilationQuery;
                    foreach (Compilable compilable in query.Query())
                    {
                        compilable.generator.GenerateClean(0).Save().Custom(compilable.path, compilable.fileName).Text(false);
                    }
                }

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}
