using SANDBOX;
using NUnit.Framework;

namespace SANDBOX_Tests
{
    public class Tests
    {
        CalcCore calc;

        [SetUp]
        public void Setup()
        {
            calc = new CalcCore();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
            //Console.WriteLine($"Result: {calc.Add(2, 2)}");
            Assert.That(calc.Add(2, 2), Is.EqualTo(4));
        }
    }
}
