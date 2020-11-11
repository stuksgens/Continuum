using UnityEngine;
using System;
using Lasm.Dependencies.Humility;

namespace Lasm.Dependencies.Editor
{
    public static class CoreGUI
    {
        public static void IconFoldout(ref bool isOpen, string label, Texture2D icon, Action content, int padding = 4)
        {
            isOpen = HUMEditor.Foldout(isOpen, new GUIContent(label, icon),
            Styles.backgroundColor.Brighten(0.05f),
            Color.black,
            1,
            () =>
            {
                HUMEditor.Vertical().Box(Styles.backgroundColor, Color.black, new RectOffset(padding, padding, padding, padding), new RectOffset(1, 1, 0, 1), () =>
                {
                    content?.Invoke();
                });
            });
        }

        public static void IconFoldout(ref bool isOpen, string label, Texture2D icon, Action content, Color background, int padding = 4)
        {
            isOpen = HUMEditor.Foldout(isOpen, new GUIContent(label, icon),
            Styles.backgroundColor.Brighten(0.05f),
            Color.black,
            1,
            () =>
            {
                HUMEditor.Vertical().Box(background, Color.black, new RectOffset(padding, padding, padding, padding), new RectOffset(1, 1, 0, 1), () =>
                {
                    content?.Invoke();
                });
            });
        }
    }
}