using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    public static class SelectionSortExtension
    {
        /// <summary>
        /// The algorithm works by selecting the smallest unsorted item
        /// and then swapping it with the item in the next position to be filled.
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseSelection<T>(this ISort sort, T[] input, IComparer<T> comparer)
        {
            var sorter = new SelectionSort<T>(comparer);
            sorter.Sort(input);
            return input;
        }

        /// <summary>
        /// The algorithm works by selecting the smallest unsorted item
        /// and then swapping it with the item in the next position to be filled.
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseSelection(this ISort sort, string input, IComparer<char> comparer = null)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var charArray = input.ToCharArray();
            var sorter = new SelectionSort<char>(comparer != null ? comparer : new AsciiValueComparer());
            sorter.Sort(charArray);
            input = new string(charArray);
            return input;
        }
    }
}
