using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// Comb Sort is mainly an improvement over Bubble Sort. Bubble sort always compares adjacent values.
    /// So all inversions are removed one by one. Comb Sort improves on Bubble Sort by using gap of size more than 1.
    /// The gap starts with a large value and shrinks by a factor of 1.3 in every iteration until it reaches the value 1.
    /// Thus Comb Sort removes more than one inversion counts with one swap and performs better than Bubble Sort.
    ///The shrink factor has been empirically found to be 1.3 (by testing Combsort on over 200,000 random lists)
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class CombSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public CombSort(IComparer<T> comparer)
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
            // initialize gap
            int gap = n;
            // iniitaliz swappd as true tomake sure that loop runs
            bool swapped = true;
            // Keep running while gap is more than  
            // 1 and last iteration caused a swap 
            while(gap != 1 || swapped == true)
            {
                // find next gap;
                gap = this.GetNextGap(gap);
                // Initialize swapped as false so that we can 
                // check if swap happened or not 
                swapped = false;
                // Compare all elements with current gap 
                for (int i=0; i<n-gap; i++)
                {
                    if(_comparer.Compare(input[i], input[i+gap]) > 0)
                    {
                        var temp = input[i];
                        input[i] = input[i + gap];
                        input[i + gap] = temp;

                        // set swapped
                        swapped = true;
                    }
                }
            }
        }

        private int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if(gap < 1)
            {
                return 1;
            }

            return gap;
        }
    }
}
