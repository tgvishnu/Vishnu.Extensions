using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// Counting sort is a sorting technique based on keys between a specific range.
    /// It works by counting the number of objects having distinct key values (kind of hashing).
    /// Then doing some arithmetic to calculate the position of each object in the output sequence
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class CountingSort<T> : ISortingAlgorithm<T>
    {
        private readonly Func<T, int> _propertySelector;

        /// <summary>
        /// Creates new instance of <see cref="CountingSort{T}"/> class.
        /// </summary>
        /// <param name="propertySelector">property selector</param>
        public CountingSort(Func<T, int> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public void Sort(T[] input)
        {
            List<int> buckets = new List<int>();
            for(int ii=0; ii<input.Length; ii++)
            {
                int value = _propertySelector(input[ii]);
                for(int j= buckets.Count; j<= value; j++)
                {
                    buckets.Add(0);
                }

                buckets[value]++;
            }

            int[] startIndex = new int[buckets.Count];
            for(int j = 1; j< startIndex.Length; j++)
            {
                startIndex[j] = buckets[j - 1] + startIndex[j - 1];
            }

            T[] result = new T[input.Length];
            for(int i =0; i<input.Length; i++)
            {
                int value = _propertySelector(input[i]);
                int destIndex = startIndex[value]++;
                result[destIndex] = input[i];
            }

            for(int i=0; i<result.Length; i++)
            {
                input[i] = result[i];
            }
        }
    }
}
