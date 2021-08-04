using System;
using System.Collections.Generic;
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
                var delimiters = new List<char> {',', '\n'};

                var numbersString = numbers;
                if (numbersString.StartsWith("//"))
                {
                    numbersString = numbers.Split('\n',2).Last();
                    var newDelimiter = numbers.Split('\n').First().Replace("//", "");

                    delimiters.Add(Convert.ToChar(newDelimiter));
                }
                 
                var sum = numbersString
                 .Split(delimiters.ToArray())
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