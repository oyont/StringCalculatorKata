using NUnit.Framework;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        private StringCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new StringCalculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}