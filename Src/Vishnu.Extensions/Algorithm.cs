using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;

namespace Vishnu.Extensions
{
    public class Algorithm : ISort
    {
        public static ISort Sorting
        {
            get
            {
                return new Algorithm();
            }
        }
    }
}
