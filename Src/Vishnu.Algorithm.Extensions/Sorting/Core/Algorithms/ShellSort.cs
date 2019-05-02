using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// ShellSort is mainly a variation of Insertion Sort. 
    /// In insertion sort, we move elements only one position ahead.
    /// When an element has to be moved far ahead, many movements are involved.
    /// The idea of shellSort is to allow exchange of far items. 
    /// In shellSort, we make the array h-sorted for a large value of h.
    /// We keep reducing the value of h until it becomes 1. 
    /// An array is said to be h-sorted if all sublists of every h’th element is sorted.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class ShellSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public ShellSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(T[] input)
        {
            int n = input.Length;
            for(int gap = n/2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for(int i=gap; i<n; i+=1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    var temp = input[i];
                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; ((j >= gap) && (_comparer.Compare(input[j - gap], temp) > 0)) ; j -=gap)
                    {
                        input[j] = input[j - gap];
                    }
                    // put temp (the original a[i])  
                    // in its correct location 
                    input[j] = temp;
                }
            }
        }
    }
}
