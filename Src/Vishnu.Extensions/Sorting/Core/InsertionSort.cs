using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    public class InsertionSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        public InsertionSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public virtual void Sort(T[] input)
        {
            for(int ii=1; ii<input.Length; ii++)
            {
                var key = input[ii];
                var jj = ii - 1;
                while(jj >=0 && (_comparer.Compare(input[jj], key) > 0))
                {
                    input[jj + 1] = input[jj];
                    jj = jj - 1;
                }

                input[jj + 1] = key;
            }
        }
    }
}
