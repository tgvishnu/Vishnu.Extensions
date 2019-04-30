using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    public class IntegerComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if(x > y)
            {
                return 1;
            }

            if(x == y)
            {
                return 0;
            }

            return -1;
        }
    }
}
