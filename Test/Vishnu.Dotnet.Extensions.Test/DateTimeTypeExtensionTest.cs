using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.DateTimeType;

namespace Vishnu.Dotnet.Extensions.Test
{
    [TestFixture]
    public class DateTimeTypeExtensionTest
    {
        [Test]
        public void Between_Test()
        {
            Assert.AreEqual(true, DateTime.Now.AddDays(1).Between(DateTime.Now, DateTime.Now.AddDays(2)));
            Assert.AreEqual(false, DateTime.Now.AddDays(-5).Between(DateTime.Now, DateTime.Now.AddDays(2)));
            Assert.AreEqual(false, DateTime.Now.AddDays(5).Between(DateTime.Now, DateTime.Now.AddDays(2)));
        }

        [Test]
        public void Age_Test()
        {
            int age = new DateTime(1983, 06, 10).Age();
            Assert.AreEqual(35, age);
        }
    }
}
