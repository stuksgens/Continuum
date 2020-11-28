using UnityEditor;

namespace Lasm.Continuum.Editor.Processing
{
    public sealed class AutoSaveProcess : GlobalProcess
    {
        public static float startTime;
        public static float currentTime;

        public override void Process()
        {
            if (EditorPrefs.GetBool("com.lasm.dependencies.AutoSave"))
            {
                var elapsed = EditorApplication.timeSinceStartup - startTime;
                if (elapsed > EditorPrefs.GetInt("com.lasm.dependencies.AutoSaveRate"))
                {
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    startTime = (float)EditorApplication.timeSinceStartup;
                }
            }
        }

        public override void OnBind()
        {
            startTime = (float)EditorApplication.timeSinceStartup;
        }
    }
}