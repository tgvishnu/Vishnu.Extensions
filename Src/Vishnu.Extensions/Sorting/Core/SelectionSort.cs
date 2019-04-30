using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    public class SelectionSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        public SelectionSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public virtual void Sort(T[] input)
        {
            int min = 0;
            for(int ii=0; ii<input.Length; ii++)
            {
                min = ii;
                for(int jj= ii+1; jj< input.Length; jj++)
                {
                    if(_comparer.Compare(input[jj], input[min]) < 0)
                    {
                        min = jj;
                    }
                }

                T temp = input[ii];
                input[ii] = input[min];
                input[min] = temp;
            }
        }
    }
}
