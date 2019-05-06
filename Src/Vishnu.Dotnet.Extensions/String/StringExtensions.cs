using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vishnu.Extensions.StringType
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtension
    {
        /// <summary>
        /// Get enum value
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="text">valule</param>
        /// <param name="ignoreCase">is case sensitive</param>
        /// <param name="result">result</param>
        /// <returns>true or false</returns>
        public static bool ToTryEnum<T>(this string text, bool ignoreCase, out T result) where T : struct
        {
            return System.Enum.TryParse<T>(text, ignoreCase, out result);
        }

        /// <summary>
        /// Get enum value
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="text">value</param>
        /// <param name="ignoreCase">is case sensitive</param>
        /// <returns>Enum value</returns>
        public static T ToEnum<T>(this string text, bool ignoreCase) where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), text, ignoreCase);
        }

        /// <summary>
        /// Get content in specified format
        /// </summary>
        /// <param name="text">format</param>
        /// <param name="argument">content</param>
        /// <returns>formated string</returns>
        public static string GetInFormat(this string text, object argument)
        {
            return string.Format(text, argument);
        }

        /// <summary>
        /// Get content in specified format
        /// </summary>
        /// <param name="text">format</param>
        /// <param name="arguments">contents</param>
        /// <returns>formated string</returns>
        public static string GetInFormat(this string text, params object[] arguments)
        {
            return string.Format(text, arguments);
        }

        /// <summary>
        /// Check if string contains in collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">array of string collection</param>
        /// <returns>true or false</returns>
        public static bool In(this string text, bool ignoreCase, params string[] stringCollection)
        {
            bool result = false;
            result = stringCollection.Where(e => string.Compare(e, text, ignoreCase) == 0).Select(e => e).Count() > 0 ? true : false;
            return result;
        }

        /// <summary>
        /// Check if string contains in collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">List of string collection</param>
        /// <returns>true or false</returns>
        public static bool In(this string text, bool ignoreCase, IList<string> stringCollection)
        {
            bool result = false;
            result = stringCollection.Where(e => string.Compare(e, text, ignoreCase) == 0).Select(e => e).Count() > 0 ? true : false;
            return result;
        }

        /// <summary>
        /// Check if any character contains in string
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="charactersCollection">array of character collection</param>
        /// <returns>true or false</returns>
        public static bool In(this string text, params char[] charactersCollection)
        {
            bool result = false;
            foreach (char character in charactersCollection)
            {
                if (text.Contains(character.ToString()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Check if any character contains in string
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="charactersCollection">List of character collection</param>
        /// <returns>true or false</returns>
        public static bool In(this string text, List<char> charactersCollection)
        {
            bool result = false;
            foreach (char character in charactersCollection)
            {
                if (text.Contains(character.ToString()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Check if specified text contains in all string collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">array of string</param>
        /// <returns>true or false</returns>
        public static bool AppearInAll(this string text, params string[] stringCollection)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(text) || stringCollection.Length > 0)
            {
                foreach (string value in stringCollection)
                {
                    if (value != null)
                    {
                        if (!value.Contains(text))
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check if specified text contains in all string collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">List of string</param>
        /// <returns>true or false</returns>
        public static bool AppearInAll(this string text, List<string> stringCollection)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(text) || stringCollection.Count > 0)
            {
                foreach (string value in stringCollection)
                {
                    if (value != null)
                    {
                        if (!value.Contains(text))
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check if specified text contains in any of string collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">array of string</param>
        /// <returns>true or false</returns>
        public static bool AppearInAny(this string text, params string[] stringCollection)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(text) || stringCollection.Length > 0)
            {
                foreach (string value in stringCollection)
                {
                    if (value != null)
                    {
                        if (value.Contains(text))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check if specified text contains in any of string collection
        /// </summary>
        /// <param name="text">value</param>
        /// <param name="stringCollection">array of string</param>
        /// <returns>true or false</returns>
        public static bool AppearInAny(this string text, IList<string> stringCollection)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(text) || stringCollection.Count > 0)
            {
                foreach (string value in stringCollection)
                {
                    if (value != null)
                    {
                        if (value.Contains(text))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get only digits from the specified string
        /// </summary>
        /// <param name="value">string content</param>
        /// <returns></returns>
        public static string GetDigits(this string value)
        {
            return new string(value?.Where(c => char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Remove last character
        /// </summary>
        /// <param name="content">content</param>
        /// <returns>string</returns>
        public static string RemoveLastCharacter(this string content)
        {
            return content.Substring(0, content.Length - 1);
        }

        /// <summary>
        /// Removes content from the position specified from last.
        /// </summary>
        /// <param name="content">content</param>
        /// <param name="index"></param>
        /// <returns>string</returns>
        public static string RemoveLast(this string content, int index)
        {
            return content.Substring(0, content.Length - index);
        }

        /// <summary>
        /// Removes first character from the string
        /// </summary>
        /// <param name="content"></param>
        /// <returns>string</returns>
        public static string RemoveFirstCharacter(this string content)
        {
            return content.Substring(1);
        }

        /// <summary>
        /// Removes characters from specified position form begining
        /// </summary>
        /// <param name="content">content</param>
        /// <param name="position">position</param>
        /// <returns>string</returns>
        public static string RemoveFirst(this string content, int position)
        {
            return content.Substring(position);
        }

        /// <summary>
        /// Split the string into parts
        /// </summary>
        /// <param name="content">content</param>
        /// <param name="size">part size</param>
        /// <returns>collection of parts</returns>
        public static IList<string> SplitOnSize(this string content, int size)
        {
            var result = new List<string>();
            int partIndex = 0;
            int length = content.Length;
            while (length > 0)
            {
                var tempPartLength = length >= size ? size : length;
                var part = content.Substring(partIndex * size, tempPartLength);
                result.Add(part);
                partIndex++;
                length -= size;
            }

            return result;
        }

        /// <summary>
        /// Split the contents based on the required sizes
        /// </summary>
        /// <param name="content">content</param>
        /// <param name="variableLengths">variable lengths</param>
        /// <returns></returns>
        public static IList<string> SplitOnSize(this string content, IList<int> variableLengths)
        {
            List<string> result = new List<string>();
            result.Clear();
            try
            {
                if (!string.IsNullOrEmpty(content) && variableLengths != null)
                {
                    int maxLenght = variableLengths.Sum();
                    if (content.Length >= maxLenght)
                    {
                        int start = 0;
                        int end = 0;
                        for (int ii = 0; ii < variableLengths.Count; ii++)
                        {
                            end = variableLengths[ii];
                            result.Add(content.Substring(start, end));
                            start = start + end;
                        }
                    }
                }
            }
            catch
            {
                //// incase of any exceptions while parsing.
                result = new List<string>();
            }

            return result;
        }

        /// <summary>
        /// Check if string is palandrome or not
        /// </summary>
        /// <param name="content">content</param>
        /// <returns>true if palandrome else false</returns>
        public static bool IsPalindrome(this string content)
        {
            int len, halfLength;
            bool bValid = true;
            len = content.Length - 1;
            halfLength = len / 2;
            for (int i = 0; i < halfLength; i++)
            {
                if (content.Substring(i, 1) != content.Substring(len - i, 1)) bValid = false;
            }

            return bValid;
        }
    }
}
