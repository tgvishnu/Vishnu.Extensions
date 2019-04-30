using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    public static class SortingExtension
    {
        public static T[] Sort<T>(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            var bubbleSort = sortingAlgorithmFactory.Get<T>(sortingTypes, comparer);
            bubbleSort.Sort(input);
            return input;
        }

        public static T[] Sort<T>(this ISort sort, SortingTypes sortingTypes, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
        }

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

        public static string Sort(this ISort sort, SortingTypes sortingTypes, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(new DefaultSortingAlgorithmFactory(), sortingTypes, input, comparer);
        }
    }
}
