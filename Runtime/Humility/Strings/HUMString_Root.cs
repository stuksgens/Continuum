using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Lasm.Continuum.Humility {
    public static partial class HUMString
    {
        public static Data.Remove Remove(this string text, string remove)
        {
            return new Data.Remove(text, remove);
        }

        public static string RemoveBetween(this string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.RightToLeft);
            return regex.Replace(sourceString, startTag + endTag);
        }

        /// <summary>
        /// Begins adding something into text.
        /// </summary>
        public static Data.Add Add(this string text)
        {
            return new Data.Add(text);
        }

        /// <summary>
        /// Begins an operation that capitalizes some text.
        /// </summary>
        public static Data.Capitalize Capitalize(this string text)
        {
            return new Data.Capitalize(text);
        }

        public static string Nice(this string str)
        {
            var split = str.Add().Space().Between().Lowercase().And().Uppercase();
            var firstLetter = split[0].ToString().ToUpper();
            var capitalized = split.Remove(0).Insert(0, firstLetter);
            return capitalized;
        }
    }
}
