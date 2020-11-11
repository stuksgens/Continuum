﻿using System;
using System.Collections;
using UnityEngine;

namespace Lasm.Dependencies.Humility
{
    public static partial class HUMGameObject
    {
        /// <summary>
        /// Starts a removing operation on a Game Object.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Data.Remove Remove(this GameObject target)
        {
            return new Data.Remove(target);
        }
    }
}