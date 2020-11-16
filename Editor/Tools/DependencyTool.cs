using UnityEditor;
using UnityEngine;
using Lasm.Utilities;

namespace Lasm.Dependencies.Editor
{
    public abstract class DependencyTool
    {
        public DependencyTool()
        {
        }

        public bool opened;

        public abstract string DisplayName { get; }

        public virtual void OnEnable()
        {
        }

        public virtual void OnGUI()
        {

        }
         
        public virtual Texture2D Icon()
        {
            return Images.Load("Tools", "tool", "lasm_dependencies_tools");
        }

        public void EnsurePref(string key, PrefType type)
        {
            if (!EditorPrefs.HasKey(key))
            {
                if (type == PrefType.Bool) EditorPrefs.SetBool(key, false);
                if (type == PrefType.Float) EditorPrefs.SetFloat(key, 0f);
                if (type == PrefType.Int) EditorPrefs.SetInt(key, 0);
                if (type == PrefType.String) EditorPrefs.SetString(key, string.Empty);
            }
        }

        public enum PrefType
        {
            Bool,
            Float,
            Int,
            String
        }
    }
}
