using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.LongType;

namespace Vishnu.Dotnet.Extensions.Test
{
    [TestFixture]
    public class LongTypeExtensionTest
    {
        [Test]
        public void ToFileSizeTest()
        {
            long l = 342113412;
            var result = 342113412L.ToFileSize();
            Assert.AreEqual("326MB", result);
        }
    }
}
