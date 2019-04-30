using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    public static class BubbleSortExtension
    {
        /// <summary>
        /// The algorithm works by comparing each item in the list with the item next to it, 
        /// and swapping them if required. In other words, 
        /// the largest element has bubbled to the top of the array. The algorithm repeats this 
        /// process until it makes a pass all the way through the list without swapping any items.
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseBubble<T>(this ISort sort, T[] input, IComparer<T> comparer)
        {
            var bubbleSort = new BubbleSort<T>(comparer);
            bubbleSort.Sort(input);
            return input;
        }

        /// <summary>
        /// The algorithm works by comparing each item in the list with the item next to it, 
        /// and swapping them if required. In other words, 
        /// the largest element has bubbled to the top of the array. The algorithm repeats this 
        /// process until it makes a pass all the way through the list without swapping any items.
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseBubble(this ISort sort, string input, IComparer<char> comparer = null)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var charArray = input.ToCharArray();
            var bubbleSort = new BubbleSort<char>(comparer != null ? comparer : new AsciiValueComparer());
            bubbleSort.Sort(charArray);
            input = new string(charArray);
            return input;
        }
    }
}
