using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// PancakeSort is similar to Selection Sort.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class PancakeSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public PancakeSort(IComparer<T> comparer)
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
            // Start from the complete 
            // array and one by one 
            // reduce current size by one 
            for(int curr_size = n; curr_size > 1; --curr_size)
            {
                // Find index of the 
                // maximum element in 
                // input[0..curr_size-1] 
                int mi = this.FindMax(input, curr_size);
                // Move the maximum element 
                // to end of current array 
                // if it's not already at  
                // the end 
                if(mi != curr_size - 1)
                {
                    // To move at the end, 
                    // first move maximum 
                    // number to beginning 
                    this.Flip(input, mi);
                    // Now move the maximum  
                    // number to end by 
                    // reversing current array 
                    this.Flip(input, curr_size - 1);
                }
            }
        }

        /// <summary>
        /// Reverses input[0..i] 
        /// </summary>
        /// <param name="input">input </param>
        /// <param name="i">to index</param>
        private void Flip(T[] input, int i)
        {
            int start = 0;
            while(start < i)
            {
                var temp = input[start];
                input[start] = input[i];
                input[i] = temp;
                start++;
                i--;
            }
        }

        /// <summary>
        /// Return index of maximum element in input
        /// </summary>
        /// <param name="input">input</param>
        /// <param name="n">items</param>
        /// <returns>max value index</returns>
        private int FindMax(T[] input, int n)
        {
            int mi, i;
            for(mi = 0, i = 0; i <n; i++)
            {
                if(_comparer.Compare(input[i], input[mi]) > 0)
                {
                    mi = i;
                }
            }

            return mi;
        }
    }
}
