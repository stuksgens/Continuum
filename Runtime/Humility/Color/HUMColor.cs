﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.Dependencies.Humility
{
    public static partial class HUMColor
    {
        /// <summary>
        /// Gets a color at index from start color to end color.
        /// </summary>
        /// <param name="start">The first color in the gradient</param>
        /// <param name="end">The last color in the gradient</param>
        /// <param name="amount">The amount of colors we can get a value back from</param>
        /// <param name="index">The current color selected based on the amount present.</param>
        /// <returns></returns>
        public static Color Between(Color start, Color end, int amount, int index)
        {
            Color colorDifference = new Color(
                       (end.r - start.r) / amount,
                       (end.g - start.g) / amount,
                       (end.b - start.b) / amount
                );

            if (index == 0)
            {
                return start;
            }

            return start + (colorDifference * (index + 1));
        }

        /// <summary>
        /// Gets the average between two colors.
        /// </summary>
        public static Color Between(Color start, Color end)
        {
            return Between(start, end, 3, 1);
        }

        /// <summary>
        /// Get a color greyscaled from black to white.
        /// </summary>
        public static Color Grey(float percent)
        {
            return new Color(percent, percent, percent);
        }

        /// <summary>
        /// Darkens the color by subtracting all values by the percent.
        /// </summary>
        public static Color Darken(this Color value, float percent)
        {
            return new Color(value.r - percent, value.g - percent, value.b - percent);
        }

        /// <summary>
        /// Lightens up the color by adding all values by the percent.
        /// </summary>
        public static Color Brighten(this Color value, float percent)
        {
            return new Color(value.r + percent, value.g + percent, value.b + percent);
        }

        /// <summary>
        /// Multiplies the color by a percent.
        /// </summary>
        public static Color Multiply(this Color value, float percent)
        {
            return new Color(value.r * percent, value.g * percent, value.b * percent);
        }

        /// <summary>
        /// Divides the color by a percent.
        /// </summary>
        public static Color Divide(this Color value, float percent)
        {
            return new Color(value.r / percent, value.g / percent, value.b / percent);
        }

        /// <summary>
        /// Creates a new texture from a color.
        /// </summary>
        public static void CacheTexture(this Color color, ref Texture2D texture)
        {
            if (texture == null)
            {
                texture = new Texture2D(1, 1);
                texture.SetPixel(0, 0, color);
                texture.Apply();
            }
        }
    }
}
