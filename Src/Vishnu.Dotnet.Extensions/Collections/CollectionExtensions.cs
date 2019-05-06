using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vishnu.Extensions.CollectionType
{
    public static partial class  CollectionExtensions
    {
        /// <summary>
        /// Join the collection with a separtor
        /// </summary>
        /// <typeparam name="T">type of contect</typeparam>
        /// <param name="enumerable">collection</param>
        /// <param name="separator">separator</param>
        /// <returns>join string</returns>
        public static string Join<T>(this IEnumerable<T> enumerable, string separator)
        {
            return string.Join(separator, enumerable.Select(e => e.ToString()).ToArray());
        }

        /// <summary>
        /// Join the array with a separtor
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="separator">separator</param>
        /// <returns>join string</returns>
        public static string Join(this Array array, string separator)
        {
            return string.Join(separator, array);
        }
    }
}
