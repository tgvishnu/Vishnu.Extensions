using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class RadixSortTest
    {
        [Test]
        public void Integer_Sort_Test()
        {
            int[] data = new int[] { 170, 45, 75, 90, int.MaxValue, 802, 24, 2, 66 };
            int[] expectedData = new int[] { 2, 24, 45, 66, 75, 90, 170, 802, int.MaxValue };
            Algorithm.Sorting.UseRadix(data);
            Assert.AreEqual(expectedData, data);
        }
    }
}
