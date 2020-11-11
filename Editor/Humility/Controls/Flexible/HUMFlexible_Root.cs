#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace Lasm.Dependencies.Humility
{
    public static partial class HUMEditor
    {
        private static Texture2D _foldoutOpenIcon;
        private static Texture2D foldoutOpenIcon
        {
            get => _foldoutOpenIcon;
            set => _foldoutOpenIcon = _foldoutOpenIcon ?? AssetDatabase.LoadAssetAtPath<Texture2D>(HUMIO.PathOf("humility_root") + "/Editor/Resources/Icons/foldout_open.png");
        }

        private static Texture2D _foldoutClosedIcon;
        private static Texture2D foldoutClosedIcon
        {
            get => _foldoutClosedIcon;
            set => _foldoutClosedIcon = _foldoutClosedIcon ?? AssetDatabase.LoadAssetAtPath<Texture2D>(HUMIO.PathOf("humility_root") + "/Editor/Resources/Icons/foldout_open.png");
        }

        public static Data.Flexible Draw()
        {
            return new Data.Flexible();
        }

        public static void Horizontal(Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(options);
            action();
            EditorGUILayout.EndHorizontal();
        }

        public static Data.Horizontal Horizontal()
        {
            return new Data.Horizontal();
        }

        public static void Horizontal(GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(style, options);
            action();
            EditorGUILayout.EndHorizontal();
        }

        public static Data.Vertical Vertical()
        {
            return new Data.Vertical();
        }

        public static void Vertical(Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(options);
            action();
            EditorGUILayout.EndVertical();
        }

        public static void Vertical(GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(style, options);
            action();
            EditorGUILayout.EndVertical();
        }

        public static bool Foldout(bool isOpen, GUIContent label, Color backgroundColor, Color borderColor, int border = 1, Action whileOpen = null)
        {
            var foldout = false;
            Vertical().Box(backgroundColor, borderColor, new RectOffset(2, 2, 2, 2), TextAnchor.MiddleLeft, border, () =>
            {
                Horizontal(() =>
                {
                    foldout = EditorGUILayout.Toggle(isOpen, new GUIStyle(EditorStyles.foldout), GUILayout.Width(16));
                    GUILayout.Box(GUIContent.none, new GUIStyle() { normal = new GUIStyleState() { background = (Texture2D)label.image }, margin = new RectOffset(0, 0, 3, 0) }, GUILayout.Width(16), GUILayout.Height(16));
                    GUILayout.Label(label.text);
                });
            });

            if (!foldout)
            {
                return false;
            }

            whileOpen();

            return true;
        }

        public static bool Foldout(bool isOpen, Color backgroundColor, Color borderColor, int border = 1, Action header = null, Action whileOpen = null)
        {
            var foldout = false;
            Vertical().Box(backgroundColor, borderColor, new RectOffset(2, 2, 2, 2), TextAnchor.MiddleLeft, border, () =>
            {
                Horizontal(() =>
                {
                    foldout = EditorGUILayout.Toggle(isOpen, new GUIStyle(EditorStyles.foldout), GUILayout.Width(16));
                    header?.Invoke();
                });
            });

            if (!foldout)
            {
                return false;
            }

            whileOpen();

            return true;
        }

        public static bool Foldout(bool isOpen, string label, Color backgroundColor, Color borderColor, int border = 1, Action whileOpen = null)
        {
            var foldout = false;
            Vertical().Box(backgroundColor, borderColor, new RectOffset(20, 0, 0, 0), TextAnchor.MiddleLeft, border, () =>
            {
                Horizontal(() =>
                {
                    foldout = EditorGUILayout.Toggle(isOpen, new GUIStyle(EditorStyles.foldout), GUILayout.Width(16));
                    GUILayout.Label(label);
                });
            });

            if (!foldout)
            {
                return false;
            }

            whileOpen();

            return true;
        }

        public static void LostFocus(ref string focusedControl, string controlName, Action onControl, Action onLostFocus)
        {
            GUI.SetNextControlName(controlName);
            onControl?.Invoke();
            if (GUI.GetNameOfFocusedControl() == controlName)
            {
                if (focusedControl != controlName)
                {
                    focusedControl = controlName;
                }
            }
            else
            {
                if (focusedControl == controlName)
                {
                    onLostFocus?.Invoke();
                    focusedControl = string.Empty;
                }
            }
        }

        public static void Focus(string controlName, Action onFocused, Action onNotFocused)
        {
            if (GUI.GetNameOfFocusedControl() == controlName)
            {
                onFocused?.Invoke();
            }
            else
            {
                onNotFocused?.Invoke();
            }
        }
    }
}
#endif