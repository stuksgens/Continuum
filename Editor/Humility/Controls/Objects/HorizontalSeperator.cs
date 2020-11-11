﻿using UnityEngine;
using UnityEngine.UIElements;

namespace Lasm.Dependencies.Humility
{
    public class HorizontalSeperator : VisualElement
    {
        public HorizontalSeperator(int thickness, Color color)
        {
            this.Set().Margin(4);
            style.width = thickness; 

            var rectangle = new Rectangle(color);
            rectangle.StretchToParentSize();

            Add(rectangle);
        }
    }
}
