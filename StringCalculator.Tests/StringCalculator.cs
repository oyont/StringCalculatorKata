using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Tests
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var delimiters = new List<string> { ",", "\n" };
             
            if (numbers.StartsWith("//"))
            {
                var delimiter = numbers.Split('\n').First().Replace("//", "");

                var customDelimiters = delimiter.Split("][",StringSplitOptions.RemoveEmptyEntries).Select(d=> d.Replace("[","").Replace("]",""));
                 
                 
                delimiters.AddRange(customDelimiters); 
                numbers = numbers.Split('\n', 2).Last();
            }

            var numbersToSum = numbers
             .Split(delimiters.ToArray(), StringSplitOptions.None)
             .Select(int.Parse)
             .Where(x => x <= 1000);

            var negatives = numbersToSum.Where(x => x < 0).ToList();

            if (negatives.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negatives)}");
            }


            return numbersToSum.Sum();

        }
    }
}