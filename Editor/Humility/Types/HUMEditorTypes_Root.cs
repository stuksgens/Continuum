﻿using UnityEditor;
using System.Reflection;
using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace Lasm.Dependencies.Humility
{
    public static partial class HUMEditorTypes
    {
        /// <summary>
        /// Begins getting something that deals with the editor.
        /// </summary>
        public static Data.Get Get()
        {
            return new Data.Get();
        }

        /// <summary>
        /// The rect position of the Unity editor toolbar.
        /// </summary>
        public static Rect ToolbarPosition()
        {
            var toolbar = HUMEditorTypes.Get().Main().Toolbar();
            return (Rect)toolbar.GetType().GetProperty("position").GetValue(toolbar);
        }

        /// <summary>
        /// The rect position of the Unity editor debug / status bar.
        /// </summary>
        public static Rect StatusBarPosition()
        {
            var statusBar = HUMEditorTypes.Get().Main().StatusBar();
            return (Rect)statusBar.GetType().GetProperty("position").GetValue(statusBar);
        }

        /// <summary>
        /// The rect position of the Unity editor dock area. The dock area is where all the windows are docked. The center area.
        /// </summary>
        public static Rect DockAreaPosition()
        {
            var dockArea = HUMEditorTypes.Get().Main().DockArea();
            return (Rect)dockArea.GetType().GetProperty("position").GetValue(dockArea);
        }

        /// <summary>
        /// The entire window bounds of the Unity Editor application.
        /// </summary>
        public static Rect HostViewPosition(EditorWindow window)
        {
            var hostView = HUMEditorTypes.Get().Window(window).HostView();
            return (Rect)hostView.GetType().GetProperty("position").GetValue(hostView);
        }

#if UNITY_EDITOR_WIN
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        /// <summary>
        /// Gets the active window on the Windows platform. Not a Unity EditorWindow.
        /// </summary>
        public static IntPtr GetWindow()
        {
            return GetActiveWindow();
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref WindowRect rectangle);

        /// <summary>
        /// A struct to translate the position data of the active Windows platform window.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowRect
        {
            public int x;
            public int y;
            public int width;
            public int height;
        }
#endif
    }
}
