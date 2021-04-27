using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Iqt.Base.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Sets all first letters of each word in a string to a uppercase 
        /// </summary>
        /// <param name="text">The text that needs to be refactored</param>
        /// <returns>A string where all first letter are uppercase</returns>
        public static string UppercaseFirstLetter(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            char[] a = text.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Gets the first letter of each word in a string of words
        /// </summary>
        /// <param name="text"> The string of words that the letters must be returned from </param>
        /// <returns> A list of first letters </returns>
        public static List<Char> GetAllFirstLetters(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new List<char>();
            }
            var list = new List<char>();
            string[] output = text.Split(' ');
            foreach (string s in output)
            {
                if (s.Length > 0)
                {
                    list.Add(char.ToUpper(s[0]));
                }
            }
            return list;
        }

        /// <summary>
        /// Creates a string from a list of characters
        /// </summary>
        /// <param name="characters"> The list of characters to create a string </param>
        /// <returns> A string created </returns>
        public static string CreateStringFromCharacters(this List<char> characters)
        {
            return String.Concat(characters);
        }

        /// <summary>
        /// Truncates a long string to a maximum ammount of characters with three dots at the end to indicate there are more text
        /// </summary>
        /// <param name="str">The string to be truncated</param>
        /// <param name="maxLength">The maximum amount of characters allowed</param>
        /// <returns></returns>
        public static string TruncateLongString(this string str, int maxLength)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length > maxLength)
                {

                    return str.Substring(0, Math.Min(str.Length, maxLength)) + " ...";

                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts string to <see cref="bool"/>
        /// </summary>
        /// <param name="value">The value to be translated to <see cref="bool"/></param>
        /// <returns>A boolean value</returns>
        public static bool ToBoolean(this string value)
        {
            switch (value.ToLower())
            {
                case "true":
                    return true;
                case "t":
                    return true;
                case "1":
                    return true;
                case "0":
                    return false;
                case "false":
                    return false;
                case "f":
                    return false;
                default:
                    throw new InvalidCastException("You can't cast a weird value to a bool!");
            }
        }

        /// <summary>
        /// Converts Html to plain text string
        /// </summary>
        /// <param name="html">The html that needs to be translated</param>
        /// <returns>A plain text string</returns>
        public static string HtmlToPlainText(this string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            if (!string.IsNullOrEmpty(html))
            {
                var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
                var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
                var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

                var text = html;
                //Decode html specific characters
                text = System.Net.WebUtility.HtmlDecode(text);
                //Remove tag whitespace/line breaks
                text = tagWhiteSpaceRegex.Replace(text, "><");
                //Replace <br /> with line breaks
                text = lineBreakRegex.Replace(text, Environment.NewLine);
                //Strip formatting
                text = stripFormattingRegex.Replace(text, string.Empty);

                return text;
            }
            return html;
        }

        public static string RemoveNewlineFromString(this string text)
        {
            return Regex.Replace(text, @"\t|\n|\r", "");
        }

        /// <summary>
        /// Removes the last character from a string
        /// </summary>
        /// <param name="s">The string that has the last character that needs to be removed</param>
        /// <returns>a string with the last character removed</returns>
        public static String RemoveLastChar(this String s)
        {
            return string.IsNullOrEmpty(s)
                ? null
                : (s.Substring(0, s.Length - 1));
        }

        /// <summary>
        /// Splits a string into a list with a delimiter
        /// </summary>
        /// <param name="text">The string that needs to be split into a list</param>
        /// <param name="delimiter">The delimiter used as splitter</param>
        /// <returns></returns>
        public static ICollection<string> GetDelimiterList(string text, string delimiter)
        {
            return text.Split(delimiter).ToList();
        }
    }
}
