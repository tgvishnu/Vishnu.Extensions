using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    public class AsciiValueComparer : IComparer<char>
    {
        private IComparer<int> _comparer;
        public AsciiValueComparer(IComparer<int> lengthComparer = null)
        {
            if (lengthComparer == null)
            {
                _comparer = new IntegerComparer();
            }
            else
            {
                _comparer = lengthComparer;
            }
        }

        public int Compare(char x, char y)
        {
            int asciiX = (int)x;
            int asciiY = (int)y;
            return _comparer.Compare(asciiX, asciiY);
        }
    }
}
