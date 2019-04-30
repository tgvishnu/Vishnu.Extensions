using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Generic sorting methods
    /// </summary>
    public static class GenericSortingExtension
    {
        /// <summary>
        /// Sorts input based on the <see cref="SortingTypes"/> and <see cref="ISortingAlgorithmFactory"/>
        /// </summary>
        /// <typeparam name="T">Type of input</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory"><see cref="ISortingAlgorithmFactory"/></param>
        /// <param name="sortingTypes"><see cref="SortingTypes"/></param>
        /// <param name="input">input</param>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        /// <returns>Sorted input</returns>
        public static T[] Sort<T>(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            var bubbleSort = sortingAlgorithmFactory.Get<T>(sortingTypes, comparer);
            bubbleSort.Sort(input);
            return input;
        }

        /// <summary>
        /// Sorts input based on the <see cref="SortingTypes"/> using <see cref="DefaultSortingAlgorithmFactory"/>
        /// </summary>
        /// <typeparam name="T">Type of input</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingTypes"><see cref="SortingTypes"/></param>
        /// <param name="input">input</param>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        /// <returns>Sorted input</returns>
        public static T[] Sort<T>(this ISort sort, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
        }

        /// <summary>
        /// Sorts input based on <see cref="SortingTypes"/> and <see cref="ISortingAlgorithmFactory"/>
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory"><see cref="ISortingAlgorithmFactory"/></param>
        /// <param name="sortingTypes"><see cref="SortingTypes"/></param>
        /// <param name="input">input</param>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        /// <returns>sorted input</returns>
        public static string Sort(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, SortingTypes sortingTypes, string input, IComparer<char> comparer = null)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var charArray = input.ToCharArray();
            var sorter = sortingAlgorithmFactory.Get<char>(sortingTypes, comparer != null ? comparer : new AsciiValueComparer());
            sorter.Sort(charArray);
            input = new string(charArray);
            return input;
        }

        /// <summary>
        /// Sorts input based on <see cref="SortingTypes"/> and <see cref="DefaultSortingAlgorithmFactory"/>
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingTypes"><see cref="SortingTypes"/></param>
        /// <param name="input">input</param>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        /// <returns>sorted input</returns>

        public static string Sort(this ISort sort, SortingTypes sortingTypes, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
        }
    }
}
