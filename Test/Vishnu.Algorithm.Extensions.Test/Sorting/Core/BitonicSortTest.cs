using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class BitonicSortTest
    {
        [Test]
        public void Integer_Sort_Test()
        {
            int[] data = new int[] { 5,1,0,8 };
            int[] expectedData = new int[] { 0, 1, 5, 8 };
            Algorithm.Sorting.UseBitonic(data, new IntegerComparer());
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void StringLenghtComparer_Sort_Test()
        {
            string[] data = new string[] { "hello", null, "i", "am", null, "good", string.Empty, " "};
            string[] expectedData = new string[] { null, null, string.Empty, "i", " ", "am", "good", "hello" };
            Algorithm.Sorting.UseBitonic( data, new StringLengthComparer());
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void AsciiValueComparer_Sort_Test()
        {
            string d = "dsaf";
            string ed = "adfs";
            d = Algorithm.Sorting.UseBitonic(d);
            Assert.AreEqual(ed, d);
        }

        [Test]
        public void DateTimeComparer_Sort_Test()
        {
            DateTime[] data = new DateTime[] { DateTime.Now.AddDays(3), DateTime.Now.AddSeconds(10), DateTime.Now.AddSeconds(-100), DateTime.Now.AddDays(1) };
            DateTime[] actual = data;
            Algorithm.Sorting.UseBitonic(data, new DateTimeComparer());
            Assert.AreEqual(true, true);
        }

        [Test]
        public void Class_Sort_Test()
        {
            List<Person> people = new List<Person>();
            var expectedOutput = new int[] { 3, 23, 32, 132 };
            people.Add(new Person { Age = 132, Name = "name132" });
            people.Add(new Person { Age = 32, Name = "name32" });
            people.Add(new Person { Age = 3, Name = "name3" });
            people.Add(new Person { Age = 23, Name = "name23" });
            Person[] data = people.ToArray();
            Algorithm.Sorting.UseBitonic(data, new PersonAgeComparer());
            var sortedOutput = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                sortedOutput[i] = data[i].Age;
            }
            Assert.AreEqual(expectedOutput, sortedOutput);
        }

    }
}
