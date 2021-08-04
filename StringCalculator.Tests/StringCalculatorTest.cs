using System;
using FluentAssertions;
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
        public void Add_Returns_0_When_Given_Empty_String()
        {
            var result = _sut.Add("");

            result.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Add_Returns_Sum_When_Given_1_Number(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        public void Add_Returns_Sum_When_Given_2_Numbers(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [Test] 
        public void Add_Should_Handle_Unknown_Number()
        {
            Action action = () => { _sut.Add("a"); };

            action.Should().Throw<ArgumentException>() 
                .WithMessage("Unknown number");
        }
    }
}