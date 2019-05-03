using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class NaivePatternTest
    {
        [Test]
        public void SuccessTest()
        {
            string text = "AABAACAADAABAAABAA";
            string pattern = "AABA";
            IList<int> exptecedResult = new List<int>() { 0, 9, 13 };
            var result = Algorithm.PatternSearch.UseNaive(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
