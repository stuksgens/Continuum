using UnityEditor;

namespace Lasm.Dependencies.Editor.Processing
{
    public sealed class AutoSaveProcess : GlobalProcess
    {
        public static float startTime;
        public static float currentTime;

        public override void Process()
        {
            if (EditorPrefs.GetBool("LifeandStyleMedia_Dependencies_AutoSave"))
            {
                var elapsed = EditorApplication.timeSinceStartup - startTime;
                if (elapsed > EditorPrefs.GetInt("LifeandStyleMedia_Dependencies_AutoSave"))
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