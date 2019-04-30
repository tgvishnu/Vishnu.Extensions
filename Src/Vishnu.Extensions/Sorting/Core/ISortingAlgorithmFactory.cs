using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;

namespace Vishnu.Extensions.Sorting.Core
{
    public interface ISortingAlgorithmFactory
    {
        ISortingAlgorithm<T> Get<T>(SortingTypes sortingTypes, IComparer<T> comparer);
    }
}
