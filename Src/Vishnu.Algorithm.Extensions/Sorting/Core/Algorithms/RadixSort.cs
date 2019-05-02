using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    ///Radix Sort is to do digit by digit sort starting from least significant digit to most significant digit.
    ///Radix sort uses counting sort as a subroutine to sort.
    ///The Radix Sort Algorithm
    /// 1) Do following for each digit i where i varies from least significant digit to the most significant digit.
    /// a) Sort input array using counting sort(or any stable sort) according to the i’th digit.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class RadixSort : ISortingAlgorithm<int>
    {
        private readonly IComparer<int> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="RadixSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public RadixSort(IComparer<int> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(int[] input)
        {
            int n = input.Length;
            int m = this.GetMax(input, n);
            for(int exp = 1; m / exp > 0; exp *= 10)
            {
                this.CountSort(input, n, exp);
            }
        }

        private void CountSort(int[] input, int n, int exp)
        {
            // output array
            int[] output = new int[n];
            int i;
            int[] count = new int[10];
            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
            {
                count[i] = 0;
            }

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(input[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(input[i] / exp) % 10] - 1] = input[i];
                count[(input[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
                input[i] = output[i];
        }

        private int GetMax(int[] input, int n)
        {
            int mx = input[0];
            for(int ii=1; ii<n; ii++)
            {
                if(_comparer.Compare(input[ii], mx) > 0)
                {
                    mx = input[ii];
                }
            }

            return mx;
        }
    }
}
