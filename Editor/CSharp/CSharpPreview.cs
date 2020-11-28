using Lasm.Continuum.Editor;
using Lasm.Continuum.Humility;
using UnityEditor;
using UnityEngine;

namespace Lasm.Continuum.CSharp.Editor
{
    public sealed class CSharpPreview : EditorWindow
    {
        public static CSharpPreview instance;

        string output = string.Empty;

        [SerializeField]
        private Vector2 scrollPosition;

        public static Color background => Styles.backgroundColor.Darken(0.1f);

        private GUIStyle labelStyle;

        [SerializeField]
        private bool shouldRefresh = true;

        [SerializeReference]
        private ICodeGenerator _code;
        public ICodeGenerator code
        {
            get => _code;
            set
            {
                _code = value;
                Refresh();
            }
        }

        public void Refresh()
        {
            shouldRefresh = true;
            Repaint();
        }

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
            var shouldRepaint = false;

            scrollPosition = HUMEditor.Draw().ScrollView(scrollPosition, () =>
            {
                HUMEditor.Vertical().Box(background, 10, () =>
                {
                    if (code != null)
                    {
                        if (shouldRefresh)
                        {
                            output = code.Generate(0);
                            shouldRefresh = false;
                            output = output.Replace("/*", "<color=#CC3333>/*");
                            output = output.Replace("*/", "*/</color>");
                            output = output.RemoveMarkdown();
                            labelStyle = new GUIStyle(GUI.skin.label) { richText = true, stretchWidth = true, stretchHeight = true, alignment = TextAnchor.UpperLeft, wordWrap = true };
                            labelStyle.normal.background = null;
                            shouldRepaint = true;
                        }
                    }

                    if (labelStyle == null)
                    {
                        labelStyle = new GUIStyle(GUI.skin.label) { richText = true, stretchWidth = true, stretchHeight = true, alignment = TextAnchor.UpperLeft, wordWrap = true };
                        labelStyle.normal.background = null;
                    }

                    GUILayout.Label(output, labelStyle);

                }, true, true);
            });

            if (shouldRepaint) Repaint();
        }
    }
}
