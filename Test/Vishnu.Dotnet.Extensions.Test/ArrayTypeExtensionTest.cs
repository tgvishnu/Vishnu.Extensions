using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.ArrayType;

namespace Vishnu.Dotnet.Extensions.Test
{
    [TestFixture]
    public class ArrayTypeExtensionTest
    {
        [Test]
        public void PPPStuffTest()
        {
            var input = new byte[] { 0x0D, 0x0A, 0x7e, 0x7d };
            var stuffedContent = input.PPPByteStuff();
            var expectedOutput = new byte[] { 0x0D, 0x0A, 0x7d, 0x7d, 0x5d };
            Assert.AreEqual(stuffedContent, expectedOutput);
            var destuffContent = stuffedContent.PPPByteDeStuff();
            Assert.AreEqual(destuffContent, input);
        }

        [Test]
        public void PPPErrorStuffTest()
        {
            var input = new byte[] { 0x0D, 0x0A, 0x7d, 0x7d };
            Assert.Throws<Exception>(() => input.PPPByteDeStuff());
        }
    }
}
