using Lasm.Utilities;
using UnityEditor;
using UnityEngine;

namespace Lasm.Dependencies.Editor
{
    public sealed class AutoSaveTool : DependencyTool
    {
        private bool autoSave;
        private int autoSaveRate = 120;

        public override string DisplayName => "Auto Save";

        public AutoSaveTool() : base() { }

        public override void OnEnable()
        {
            EnsurePref("com.lasm.dependencies.AutoSave", PrefType.Bool);
            EnsurePref("com.lasm.dependencies.AutoSaveRate", PrefType.Int);
            autoSave = EditorPrefs.GetBool("com.lasm.dependencies.AutoSave");
            autoSaveRate = EditorPrefs.GetInt("com.lasm.dependencies.AutoSaveRate");
            if (autoSaveRate == 0) autoSaveRate = 120;
        }

        public override void OnGUI()
        {
            autoSave = GUILayout.Toggle(autoSave, "Auto Save");
            autoSaveRate = EditorGUILayout.IntSlider("Save Rate (Seconds)", autoSaveRate, 10, 600);
            if (EditorPrefs.GetBool("com.lasm.dependencies.AutoSave") != autoSave) EditorPrefs.SetBool("com.lasm.dependencies.AutoSave", autoSave);
            if (EditorPrefs.GetInt("com.lasm.dependencies.AutoSaveRate") != autoSaveRate) EditorPrefs.SetInt("com.lasm.dependencies.AutoSaveRate", autoSaveRate);
        }

        public override Texture2D Icon()
        {
            return Images.Load("Tools", "save", "lasm_dependencies_tools");
        }
    }
}
