using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{ 
    public class BubbleSort<T> : ISorting<T>
    {
        private readonly IComparer<T> _comparer = null;
        public BubbleSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public virtual void Sort(T[] input)
        {
            for(int ii = (input.Length - 1); ii >= 0; ii--)
            {
                for(int jj = 1; jj <= ii; jj++)
                {
                    if(_comparer.Compare(input[jj - 1], input[jj]) > 0 )
                    {
                        var temp = input[jj - 1];
                        input[jj - 1] = input[jj];
                        input[jj] = temp;
                    }
                }
            }
        }
    }
}
