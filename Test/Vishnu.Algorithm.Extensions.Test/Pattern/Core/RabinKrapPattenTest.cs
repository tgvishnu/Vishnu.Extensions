using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class RabinKrapPattenTest
    {
        [Test]
        public void SuccessTest()
        {
            string text = "ABABDABACDABABCABAB";
            string pattern = "ABABCABAB";
            IList<int> exptecedResult = new List<int>() {  10 };
            var result = Algorithm.PatternSearch.UseRabinKrap(text, pattern, 101);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TEXT";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10 };
            result = Algorithm.PatternSearch.UseRabinKrap(text, pattern, 101);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
