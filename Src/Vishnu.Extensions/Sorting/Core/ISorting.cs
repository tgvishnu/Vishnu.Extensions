using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    public interface ISorting<T>
    {
        void Sort(T[] input);
    }
}
