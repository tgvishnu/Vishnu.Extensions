using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class CountingSortTest
    {
        [Test]
        public void Integer_Sort_Test()
        {
            int[] data = new int[] { 170, 45, 75, 90, 802, 24, 2, 66 };
            int[] expectedData = new int[] { 2, 24, 45, 66, 75, 90, 170, 802};
            Algorithm.Sorting.UseCounting(data, (x) => { return x; });
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void StringLenghtComparer_Sort_Test()
        {
            string[] data = new string[] { "hello", null, "i", "am", null, "good", string.Empty, " " };
            string[] expectedData = new string[] { null, null, string.Empty, "i", " ", "am", "good", "hello" };
            Algorithm.Sorting.UseCounting(data, (x) => { return !string.IsNullOrEmpty(x) ? x.Length : 0; });
            Assert.AreEqual(expectedData, data);
        }

        [Test]
        public void AsciiValueComparer_Sort_Test()
        {
            string d = "dsaf";
            string ed = "adfs";
            d = Algorithm.Sorting.UseCounting(d);
            Assert.AreEqual(ed, d);
        }

        [Test]
        public void Class_Sort_Test()
        {
            List<Person> people = new List<Person>();
            var expectedOutput = new int[] { 2, 3, 23, 32, 132, 323 };
            people.Add(new Person { Age = 32, Name = "name32" });
            people.Add(new Person { Age = 23, Name = "name23" });
            people.Add(new Person { Age = 3, Name = "name3" });
            people.Add(new Person { Age = 2, Name = "name2" });
            people.Add(new Person { Age = 132, Name = "name132" });
            people.Add(new Person { Age = 323, Name = "name323" });
            Person[] data = people.ToArray();
            Algorithm.Sorting.UseCounting(data, x => x.Age);
            var sortedOutput = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                sortedOutput[i] = data[i].Age;
            }
            Assert.AreEqual(expectedOutput, sortedOutput);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

    }

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
                return 1;
            if (x.Age < y.Age)
                return -1;
            return 0;
        }
    }

    public class PersonSalaryComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Salary > y.Salary)
                return 1;
            if (x.Salary < y.Salary)
                return -1;
            return 0;
        }
    }

}
