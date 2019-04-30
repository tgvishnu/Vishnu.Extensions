using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    public class StringLengthComparer : IComparer<string>
    {
        private IComparer<int> _comparer;

        public StringLengthComparer(IComparer<int> lengthComparer = null)
        {
            if(lengthComparer == null)
            {
                _comparer = new IntegerComparer();
            }
            else
            {
                _comparer = lengthComparer;
            }
            
        }

        public int Compare(string x, string y)
        {
            int xLength = 0;
            int yLength = 0;
            if(!string.IsNullOrEmpty(x))
            {
                xLength = x.Length;
            }

            if (!string.IsNullOrEmpty(y))
            {
                yLength = y.Length;
            }

            return _comparer.Compare(xLength, yLength);
        }
    }
}
