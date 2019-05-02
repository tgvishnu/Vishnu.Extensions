using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Sorting.Core
{
    internal sealed class DefaultSortingAlgorithmFactory : ISortingAlgorithmFactory
    {
        public ISortingAlgorithm<T> Get<T>(SortingTypes sortingTypes, IComparer<T> comparer)
        {
            switch(sortingTypes)
            {
                case SortingTypes.Bubble:
                    return new BubbleSort<T>(comparer);
                case SortingTypes.Insertion:
                    return new InsertionSort<T>(comparer);
                case SortingTypes.Selection:
                    return new SelectionSort<T>(comparer);
                case SortingTypes.Merge:
                    return new MergeSort<T>(comparer);
                case SortingTypes.Quick_LastPivot:
                    return new QuickSortLastPivot<T>(comparer);
                case SortingTypes.Heap:
                    return new HeapSort<T>(comparer);
                case SortingTypes.Shell:
                    return new ShellSort<T>(comparer);
                case SortingTypes.Tim:
                    return new TimSort<T>(comparer);
                case SortingTypes.Comb:
                    return new CombSort<T>(comparer);
                default:
                    throw new NotImplementedException(sortingTypes.ToString());
            }
        }
    }
}
