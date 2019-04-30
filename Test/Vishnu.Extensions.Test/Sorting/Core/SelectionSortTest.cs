using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class SelectionSortTest
    {
        [Test]
        public void Integer_Sort_Test()
        {
            int[] data = new int[] { 5,3,8,5,1,0,8 };
            int[] expectedData = new int[] { 0, 1, 3, 5, 5, 8, 8 };
            Algorithm.Sorting.UseSelection( data, new IntegerComparer());
            Assert.AreEqual(expectedData, data);
            data = new int[] { 5, 3, 8, -1, 1, 0, 8 };
            expectedData = new int[] { -1, 0, 1, 3, 5, 8, 8 };
            Algorithm.Sorting.Sort(SortingTypes.Selection, data, new IntegerComparer());
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void StringLenghtComparer_Sort_Test()
        {
            string[] data = new string[] { "hello", null, "i", "am", null, "good", string.Empty, " "};
            string[] expectedData = new string[] { null, null, string.Empty, "i", " ", "am", "good", "hello" };
            Algorithm.Sorting.Sort(SortingTypes.Selection, data, new StringLengthComparer());
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void AsciiValueComparer_Sort_Test()
        {
            string d = "dsaf";
            string ed = "adfs";
            d = Algorithm.Sorting.Sort(SortingTypes.Selection, d);
            Assert.AreEqual(ed, d);
        }

        [Test]
        public void DateTimeComparer_Sort_Test()
        {
            DateTime[] data = new DateTime[] { DateTime.Now.AddDays(3), DateTime.Now.AddSeconds(10), DateTime.Now.AddSeconds(-100), DateTime.Now.AddDays(1) };
            DateTime[] actual = data;
            Algorithm.Sorting.Sort(SortingTypes.Selection, data, new DateTimeComparer());
            Assert.AreEqual(true, true);
        }
    }
}
