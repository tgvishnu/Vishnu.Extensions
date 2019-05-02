using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// TimSort is a sorting algorithm based on Insertion Sort and Merge Sort.
    /// We divide the Array into blocks known as Run. 
    /// We sort those runs using insertion sort one by one and then merge those runs
    /// using combine function used in merge sort. If the size of Array is less than run,
    /// then Array get sorted just by using Insertion Sort.
    /// The size of run may vary from 32 to 64 depending upon the size of the array. 
    /// Note that merge function performs well when sizes subarrays are powers of 2. 
    /// The idea is based on the fact that insertion sort performs well for small arrays.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class TimSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;
        private readonly int _run = 32;
        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        /// <param name="run">Size of run (mod of 32)</param>
        public TimSort(IComparer<T> comparer, int run = 32)
        {
            _run = (run % 32 == 0) ? run : 32;
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(T[] input)
        {
            int n = input.Length;
            for(int i=0; i<n; i+=_run)
            {
                this.InsertionSort(input, i, Math.Min((i + _run - 1), (n - 1)));
            }

            // start merging from size RUN (or 32). It will merge  
            // to form size 64, then 128, 256 and so on ....  
            for(int size = _run; size< n; size = 2 * size)
            {
                // pick starting point of left sub array. We  
                // are going to merge arr[left..left+size-1]  
                // and arr[left+size, left+2*size-1]  
                // After every merge, we increase left by 2*size 
                for(int left = 0; left < n; left += 2 * size)
                {
                    // find ending point of left sub array  
                    // mid+1 is starting point of right sub array 
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));
                    // merge sub array arr[left.....mid] &  
                    // arr[mid+1....right] 
                    this.Merge(input, left, mid, right);
                }
            }

        }

        private void InsertionSort(T[] input, int left, int right)
        {
            for(int i= left + 1; i <= right; i++)
            {
                var temp = input[i];
                int j = i - 1;
                while(j >= left && _comparer.Compare(input[j], temp) > 0 )
                {
                    input[j + 1] = input[j];
                    j--;
                }

                input[j + 1] = temp;
            }
        }

        private void Merge(T[] input, int l, int m, int r)
        {
            // original array is broken in two parts  
            // left and right array 
            int len1 = m - l + 1;
            int len2 = r - m;
            T[] left = new T[len1];
            T[] right = new T[len2];
            for(int x=0; x<len1; x++)
            {
                left[x] = input[l + x];
            }

            for(int x=0; x<len2; x++)
            {
                right[x] = input[m + 1 + x];
            }

            int i = 0, j = 0, k = l;
            // after comparing, we merge those two array  
            // in larger sub array  
            while (i < len1 && j < len2)
            {
                if(_comparer.Compare(left[i], right[j]) < 1)
                {
                    input[k] = left[i];
                    i++;
                }
                else
                {
                    input[k] = right[j];
                    j++;
                }

                k++;
            }

            // copy remaining elements of left, if any
            while(i < len1)
            {
                input[k] = left[i];
                k++;
                i++;
            }

            // copy remaining element of right, if any  
            while(j < len2)
            {
                input[k] = right[j];
                k++;
                j++;
            }

        }
    }
}
