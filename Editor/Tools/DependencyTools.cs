using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using Lasm.Dependencies.Humility;
using System.Linq;

namespace Lasm.Dependencies.Editor
{
    [Serializable]
    public sealed class DependencyTools : EditorWindow
    {
        public static DependencyTools current;
        [SerializeReference]
        public List<DependencyTool> tools = new List<DependencyTool>();
         
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

            var removables = new List<DependencyTool>();

            for (int i = 0; i < this.tools.Count; i++)
            {
                if (!tools.Any((tool)=> { return tool == this.tools[i].GetType(); }))
                {
                    removables.Add(this.tools[i]);
                }
            }

            for (int i = 0; i < tools.Length; i++)
            {
                if (!this.tools.Any((tool) => { return tool.GetType() == tools[i]; }))
                {
                    this.tools.Add(Activator.CreateInstance(tools[i]) as DependencyTool);
                }
            }

            for (int i = 0; i < removables.Count; i++)
            {
                this.tools.Remove(removables[i]);
            }

            for (int i = 0; i < this.tools.Count; i++)
            {
                this.tools[i].OnEnable();
            }
        }

        private void OnGUI()
        {
            for (int i = 0; i < this.tools.Count; i++)
            {
                var tool = this.tools[i];
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
