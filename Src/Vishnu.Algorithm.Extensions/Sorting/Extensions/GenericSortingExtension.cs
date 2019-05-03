using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Sorting
{
    /// <summary>
    /// Generic sorting methods
    /// </summary>
    internal static class GenericSortingExtension
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
        internal static void Sort<T>(this ISorting sort, ISortingAlgorithmFactory sortingAlgorithmFactory, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            var sorter = sortingAlgorithmFactory.Get<T>(sortingTypes, comparer);
            sorter.Sort(input);
        }

        /// <summary>
        /// Sorts input based on the <see cref="SortingTypes"/> using <see cref="DefaultSortingAlgorithmFactory"/>
        /// </summary>
        /// <typeparam name="T">Type of input</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingTypes"><see cref="SortingTypes"/></param>
        /// <param name="input">input</param>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        internal static void Sort<T>(this ISorting sort, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            sort.Sort<T>(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
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
        internal static string Sort(this ISorting sort, ISortingAlgorithmFactory sortingAlgorithmFactory, SortingTypes sortingTypes, string input, IComparer<char> comparer = null)
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

        internal static string Sort(this ISorting sort, SortingTypes sortingTypes, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
        }
    }
}
