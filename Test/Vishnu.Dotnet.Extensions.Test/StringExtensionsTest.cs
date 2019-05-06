using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.String;

namespace Vishnu.Dotnet.Extensions.Test
{
    public enum NumberEnum
    {
        One,
        Two,
        Three
    }

    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void GetMd5Hash_Test()
        {
            string content = "hello";
            var hash = content.GetMd5Hash();
            var hash1 = content.GetMd5Hash();
            Assert.AreEqual(hash, hash1);
        }

        [Test]
        public void ToTryEnum_Test()
        {
            NumberEnum numberEnum;
            var result = "one".ToTryEnum<NumberEnum>(true, out numberEnum);
            Assert.AreEqual(true, result);
            var result1 = "one".ToTryEnum<NumberEnum>(false, out numberEnum);
            Assert.AreEqual(false, result1);
        }

        [Test]
        public void InFormat_Test()
        {
            var result = "Hi {0} --> {1}".GetInFormat("dude", "how are you");
            Assert.AreEqual("Hi dude --> how are you", result);
        }

        [Test]
        public void In_Test()
        {
            var result = "One".In(true, "one", "two", "three");
            Assert.AreEqual(true, result);
            result = "One".In(false, "one", "two", "three");
            Assert.AreEqual(false, result);

            result = "on,e".In(',','.');
            Assert.AreEqual(true, result);
            result = "on,e".In(new List<char>{ ',', '.'});
            Assert.AreEqual(true, result);

            result = "on?e".In(',', '.');
            Assert.AreEqual(false, result);
            result = "on>e".In(new List<char> { ',', '.' });
            Assert.AreEqual(false, result);

            result = "One".In(true, new List<string>() { "one", "two", "three" });
            Assert.AreEqual(true, result);
            result = "One".In(false, new List<string>() { "one", "two", "three" });
            Assert.AreEqual(false, result);

            result = "one".AppearInAll("one", "two one dsafa", "three one dafasf");
            Assert.AreEqual(true, result);
            result = "one".AppearInAll("one", "two one dsafa", "three dafasf");
            Assert.AreEqual(false, result);
            result = "one".AppearInAll(new List<string>() { "one", "two one dsafa", "three one dafasf" });
            Assert.AreEqual(true, result);
            result = "one".AppearInAll(new List<string>() { "one", "two dsafa", "three one dafasf" });
            Assert.AreEqual(false, result);

            result = "one".AppearInAny("", "two dsafa", "three one dafasf");
            Assert.AreEqual(true, result);
            result = "one".AppearInAny("", "two  dsafa", " dafasf");
            Assert.AreEqual(false, result);
            result = "one".AppearInAny(new List<string>() { "", "two  dsafa", "three one dafasf" });
            Assert.AreEqual(true, result);
            result = "one".AppearInAny(new List<string>() { "", " dsafa", "three  dafasf" });
            Assert.AreEqual(false, result);
        }
    }
}
