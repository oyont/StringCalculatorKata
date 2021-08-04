using System;
using System.Linq;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            try
            {
                var sum = numbers
                 .Split(',')
                 .Select(int.Parse)
                 .Sum();

                return sum;
            }
            catch (System.Exception ex)
            { 
                throw new ArgumentException("Unknown number");
            }
        }
    }
}