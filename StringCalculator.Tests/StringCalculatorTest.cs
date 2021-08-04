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

        [TestCase("1,2,3", 6)]
        [TestCase("2,3,4", 9)]
        public void Add_Should_Handle_Unknown_Amount_Of_Numbers(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3", 6)] 
        public void Add_Should_Handle_New_Lines(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("//;\n1;2", 3)] 
        public void Add_Should_Handle_Custom_Delimiters(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void Add_with_a_negative_number_will_throw_an_exception(string numbers,string message)
        {
            Action action = () => { _sut.Add(numbers); };

            action.Should().Throw<Exception>()
                .WithMessage(message);
        }

        [TestCase("1001,2", 2)]
        [TestCase("1000,2", 1002)]
        public void Numbers_greater_than_1000_should_be_ignored(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("//[|||]\n1|||2|||3", 6)]
        public void Delimiters_can_be_any_length(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("//[|][%]\n1|2%3", 6)]
        public void Allow_multiple_delimiters(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }


        [TestCase("//[|][%][;]\n1|2%3;4", 10)]
        public void Handle_multiple_delimiters_of_any_length(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }
    }
}