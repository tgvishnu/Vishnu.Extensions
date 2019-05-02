using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    ///  It divides input array in two halves, calls itself for the two halves and then merges the two sorted halves. 
    ///  The merge() function is used for merging two halves. The merge(arr, l, m, r) is key process that assumes 
    ///  that arr[l..m] and arr[m+1..r] are sorted and merges the two sorted sub-arrays into one
    /// </summary>
    /// <typeparam name="T">Type of input</typeparam>
    public class MergeSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="InsertionSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public MergeSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input</param>
        public virtual void Sort(T[] input)
        {
            this.Sort(input, 0, input.Length - 1);
        }

        /// <summary>
        /// Recursively sor the input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="l">initial value</param>
        /// <param name="r">end value</param>
        private void Sort(T[] input, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                Sort(input, l, m);
                Sort(input, m + 1, r);
                Merge(input, l, m, r);
            }
        }

        /// <summary>
        /// Merges two subarrays of input[].
        /// First subarray is input[l..m] 
        /// Second subarray is input[m+1..r] 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="r"></param>
        private void Merge(T[] input, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            /* Create temp arrays */
            T[] L = new T[n1];
            T[] R = new T[n2];
            /*Copy data to temp arrays*/
            for (int i=0; i< n1; i++)
            {
                L[i] = input[l + i];
            }

            /*Copy data to temp arrays*/
            for (int j = 0; j < n2; j++)
            {
                R[j] = input[m + 1 + j];
            }

            /* Merge the temp arrays */
            // Initial indexes of first and second subarrays 
            int ii = 0, jj = 0;
            // Initial index of merged subarry array 
            int kk = l;
            while(ii < n1 && jj < n2)
            {
                if(_comparer.Compare(L[ii], R[jj]) <= 0)
                {
                    input[kk] = L[ii];
                    ii++;
                }
                else
                {
                    input[kk] = R[jj];
                    jj++;
                }

                kk++;
            }

            /* Copy remaining elements of L[] if any */
            while (ii < n1)
            {
                input[kk] = L[ii];
                ii++;
                kk++;
            }

            /* Copy remaining elements of R[] if any */
            while (jj < n2)
            {
                input[kk] = R[jj];
                jj++;
                kk++;
            }
        }
    }
}
