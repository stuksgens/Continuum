using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using Lasm.Dependencies.Humility;
using Lasm.OdinSerializer;

namespace Lasm.Dependencies.Editor
{
    [Serializable]
    public sealed class DependencyTools : EditorWindow
    {
        public static DependencyTools current;
        [OdinSerialize]
        private Dictionary<Type, DependencyTool> previousTools = new Dictionary<Type, DependencyTool>();
        private Dictionary<Type, DependencyTool> tools = new Dictionary<Type, DependencyTool>();
        private List<Type> keys = new List<Type>();

        [MenuItem("Window/Life and Style Media/Tools")]
        public static void Open()
        {
            current = GetWindow<DependencyTools>();
            current.titleContent = new UnityEngine.GUIContent("Tools");
        }

        private void OnEnable()
        {
            current = this;

            var tools = typeof(DependencyTool).Get().Derived();

            for (int i = 0; i < tools.Length; i++)
            {
                var val = this.tools.DefineValueByKey<DependencyTool>(previousTools, tools[i],
                (tool) =>
                {
                    return tool;
                },
                (tool) =>
                {
                });
            }

            keys = this.tools.KeysToList();

            for (int i = 0; i < keys.Count; i++)
            {
                this.tools[keys[i]].OnEnable();
            }
        }

        private void OnGUI()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                var tool = tools[keys[i]];
                if (tool != null)
                {
                    tool.opened = HUMEditor.Foldout(tool.opened, new GUIContent(tool.DisplayName, tool.Icon()), Styles.backgroundColor, Styles.borderColor, 1, () =>
                    {
                        HUMEditor.Vertical().Box(Styles.backgroundColor.Brighten(0.06f), Styles.borderColor, new RectOffset(6, 6, 6, 6), new RectOffset(1, 1, 0, 1), () => { tool.OnGUI(); });
                    });
                }
            }
        }
    }
}
