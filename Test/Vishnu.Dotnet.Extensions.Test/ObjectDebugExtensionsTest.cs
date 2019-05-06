using NUnit.Framework;
using System.Collections.Concurrent;
using Vishnu.Extensions.ObjectType;
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            System.Diagnostics.Debug.WriteLine("--------ALL---------");
            this.SetLogLevel("All");
            this.LogBegin(() => "Hellow world");
            this.LogEnd(() => "Hellow world");
            this.LogDebug(() => "Hellow world");
            this.LogError(() => "Hellow world");
            this.LogExeception(new System.Exception("Hellow world"));
            this.LogFunctional(() => "Hellow world");
            this.LogInformation(() => "Hellow world");
            this.LogWarning(() => "Hellow world");
            System.Diagnostics.Debug.WriteLine("--------1---------");
            this.SetLogLevel("1");
            this.LogBegin(() => "Hellow world");
            this.LogEnd(() => "Hellow world");
            this.LogDebug(() => "Hellow world");
            this.LogError(() => "Hellow world");
            this.LogExeception(new System.Exception("Hellow world"));
            this.LogFunctional(() => "Hellow world");
            this.LogInformation(() => "Hellow world");
            this.LogWarning(() => "Hellow world");
            System.Diagnostics.Debug.WriteLine("--------2---------");
            this.SetLogLevel("2");
            this.LogBegin(() => "Hellow world");
            this.LogEnd(() => "Hellow world");
            this.LogDebug(() => "Hellow world");
            this.LogError(() => "Hellow world");
            this.LogExeception(new System.Exception("Hellow world"));
            this.LogFunctional(() => "Hellow world");
            this.LogInformation(() => "Hellow world");
            this.LogWarning(() => "Hellow world");
            System.Diagnostics.Debug.WriteLine("--------3---------");
            this.SetLogLevel("3");
            this.LogBegin(() => "Hellow world");
            this.LogEnd(() => "Hellow world");
            this.LogDebug(() => "Hellow world");
            this.LogError(() => "Hellow world");
            this.LogExeception(new System.Exception("Hellow world"));
            this.LogFunctional(() => "Hellow world");
            this.LogInformation(() => "Hellow world");
            this.LogWarning(() => "Hellow world");
        }
    }
}