using Lasm.Dependencies.Editor;
using Lasm.Dependencies.Humility;
using UnityEditor;
using UnityEngine;

namespace Lasm.Dependencies.CSharp.Editor
{
    public sealed class CSharpPreview : EditorWindow
    {
        public static CSharpPreview instance;

        string output = string.Empty;

        [SerializeField]
        private Vector2 scrollPosition;

        public static Color background => Styles.backgroundColor.Darken(0.1f);

        public static ICodeGenerator code;

        [MenuItem("Window/Life and Style Media/C# Preview")]
        private static void Open()
        {
            CSharpPreview window = GetWindow<CSharpPreview>();
            window.titleContent = new GUIContent("C# Preview");
            instance = window;
        }

        private void OnEnable()
        {
            instance = this;
        }

        private void OnGUI()
        {
            scrollPosition = HUMEditor.Draw().ScrollView(scrollPosition, () =>
            {
                HUMEditor.Vertical().Box(background, 10, () =>
                {
                    if (code != null)
                    {
                        output = code.Generate(0);
                    }

                    output = output.Replace("/*", "<color=#CC3333>/*");
                    output = output.Replace("*/", "*/</color>");
                    var labelStyle = new GUIStyle(GUI.skin.label) { richText = true, stretchWidth = true, stretchHeight = true, alignment = TextAnchor.UpperLeft, wordWrap = true };
                    labelStyle.normal.background = null;
                    GUILayout.Label(output.RemoveMarkdown(), labelStyle);

                }, true, true);
            });

            Repaint();
        }
    }
}
