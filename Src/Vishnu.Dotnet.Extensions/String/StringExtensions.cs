﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vishnu.Extensions.String
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtension
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
    }
}
