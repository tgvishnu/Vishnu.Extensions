using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vishnu.Extensions.StringType;

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
            var hash = "hello".GetMd5Hash();
            var hash1 = "hello".GetMd5Hash();
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

            result = "on,e".In(',', '.');
            Assert.AreEqual(true, result);
            result = "on,e".In(new List<char> { ',', '.' });
            Assert.AreEqual(true, result);

            result = "on?e".In(',', '.');
            Assert.AreEqual(false, result);
            result = "on>e".In(new List<char> { ',', '.' });
            Assert.AreEqual(false, result);

            result = "One".In(true, new List<string>() { "one", "two", "three" });
            Assert.AreEqual(true, result);
            result = "One".In(false, new List<string>() { "one", "two", "three" });
            Assert.AreEqual(false, result);

        }

        [TestCase]
        public void AppearInAll_Test()
        {
            var result = "one".AppearInAll("one", "two one dsafa", "three one dafasf");
            Assert.AreEqual(true, result);
            result = "one".AppearInAll("one", "two one dsafa", "three dafasf");
            Assert.AreEqual(false, result);
            result = "one".AppearInAll(new List<string>() { "one", "two one dsafa", "three one dafasf" });
            Assert.AreEqual(true, result);
            result = "one".AppearInAll(new List<string>() { "one", "two dsafa", "three one dafasf" });
            Assert.AreEqual(false, result);

        }

        [Test]
        public void AppearInAny_Test()
        {
            var result = "one".AppearInAny("", "two dsafa", "three one dafasf");
            Assert.AreEqual(true, result);
            result = "one".AppearInAny("", "two  dsafa", " dafasf");
            Assert.AreEqual(false, result);
            result = "one".AppearInAny(new List<string>() { "", "two  dsafa", "three one dafasf" });
            Assert.AreEqual(true, result);
            result = "one".AppearInAny(new List<string>() { "", " dsafa", "three  dafasf" });
            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetDigits_Test()
        { 
            var resString = "ab23-432-5dfg".GetDigits();
            Assert.AreEqual("234325", resString);
        }

        [Test]
        public void Position_Test()
        {
            var input = "hello";
            Assert.AreEqual(input.RemoveLast(2), "hel");
            Assert.AreEqual(input.RemoveLastCharacter(), "hell");
            Assert.AreEqual(input.RemoveFirst(2), "llo");
            Assert.AreEqual(input.RemoveFirstCharacter(), "ello");
        }

        [Test]
        public void SplitOnSize_Test()
        {
            string longString = "This is a very long string, which we want to split on smaller parts every max. 30 characters long."; 
            var partLength = 30;
            var parts = longString.SplitOnSize(partLength);
            Assert.AreEqual(parts.Count, 4);
        }

        [Test]
        public void Palandrome_Test()
        {
            Assert.AreEqual(false, "earljon".IsPalindrome());
            Assert.AreEqual(true, "abcba".IsPalindrome());
        }

        [Test]
        public void SplitOnLength_Test()
        {
            string longString = "This is a very long string"; 
            var parts = longString.SplitOnSize(new List<int>() { 3, 5, 3 });
            Assert.AreEqual(parts.Count, 3);
        }

        [Test]
        public void InitCaps_Test()
        {
            Assert.AreEqual("hello".InitCaps(), "Hello");
        }

        [Test]
        public void WordCount_Test()
        {
            string longString = "This is a very long string.  I am good.";
            var parts = longString.WordCount(new List<char> { ' ', ',', '.' });
            Assert.AreEqual(parts, 9);
        }
    }
}
