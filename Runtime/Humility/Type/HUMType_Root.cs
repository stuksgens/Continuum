﻿using System;
using System.Reflection;

namespace Lasm.Continuum.Humility
{
    public static partial class HUMType
    {
        /// <summary>
        /// Does this type have a field or method with a type.
        /// </summary>
        internal static bool HasFieldOrMethodOfType<T>(this System.Type type, bool fields = true, bool methods = true)
        {
            var _fields = type.GetFields();
            var _methods = type.GetMethods();

            for (int i = 0; i < _fields.Length; i++)
            {
                if (_fields[i].FieldType == typeof(T))
                {
                    return true;
                }
            }

            for (int i = 0; i < _methods.Length; i++)
            {
                if (_methods[i].ReturnType == typeof(T))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Begins the operation of getting some data based on this type.
        /// </summary>
        public static Data.Get Get(this Type type)
        {
            return new Data.Get(type);
        }

        /// <summary>
        /// Begins the operation of conversions for a type.
        /// </summary>
        public static Data.As As(this Type type)
        {
            return new Data.As(type);
        }

        /// <summary>
        /// Begins the operation of comparing a type.
        /// </summary>
        public static Data.Is Is(this Type type)
        {
            return new Data.Is(type);
        }

        /// <summary>
        /// Returns true if the type inherits from a type.
        /// </summary>
        public static bool Inherits(this System.Type type, System.Type inheritsFrom)
        {
            return inheritsFrom.IsAssignableFrom(type);
        }

        /// <summary>
        /// Returns true if the type inherits from a type.
        /// </summary>
        public static bool Inherits<TInheritsFrom>(this System.Type type)
        {
            return typeof(TInheritsFrom).IsAssignableFrom(type);
        }

        /// <summary>
        /// Returns true if the type inherits from a type.
        /// </summary>
        public static bool Inherits<TType, TInheritsFrom>()
        {
            return typeof(TInheritsFrom).IsAssignableFrom(typeof(TType));
        }

        public static bool Overridable(this MethodInfo method)
        {
            if (method.IsVirtual || method.IsAbstract)
            {
                if (!method.IsSpecialName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}