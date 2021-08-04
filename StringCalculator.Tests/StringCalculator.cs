using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        private List<string> _delimiters = new List<string> { ",", "\n" };
        private const string CUSTOM_DELIMITER_INDICATOR = "//";

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
             
            if (numbers.StartsWith(CUSTOM_DELIMITER_INDICATOR))
            {
                numbers = AdCustomDelimiter(numbers);
            }

            var numbersToSum = ParseNumbersToSum(numbers);

            CheckNegativeNumbers(numbersToSum);
             
            return numbersToSum.Sum();

        }

        private static void CheckNegativeNumbers(List<int> numbersToSum)
        {
            var negatives = numbersToSum.Where(x => x < 0).ToList();

            if (negatives.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negatives)}");
            }
        }

        private List<int> ParseNumbersToSum(string numbers)
        { 
            return numbers
                .Split(_delimiters.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .Where(x => x <= 1000).ToList();
        }

        private string AdCustomDelimiter(string numbers)
        { 
            var delimiter = numbers.Split('\n').First().Replace(CUSTOM_DELIMITER_INDICATOR, "");

            var customDelimiters = delimiter.Split("][", StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Replace("[", "").Replace("]", ""));
             
            _delimiters.AddRange(customDelimiters);
            numbers = numbers.Split('\n', 2).Last();
            return numbers;
        }
    }
}