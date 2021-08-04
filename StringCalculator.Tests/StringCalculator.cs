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
             
                var delimiters = new List<char> {',', '\n'};

                var numbersString = numbers;
                if (numbersString.StartsWith("//"))
                {
                    numbersString = numbers.Split('\n',2).Last();
                    var newDelimiter = numbers.Split('\n').First().Replace("//", "");

                    delimiters.Add(Convert.ToChar(newDelimiter));
                }
                 
                var numbersToSum = numbersString
                 .Split(delimiters.ToArray()) 
                 .Select(int.Parse)
                 .Where(x => x <= 1000);

                var negatives = numbersToSum.Where(x => x < 0).ToList();

                if (negatives.Any())
                {
                    throw new Exception($"Negatives not allowed: {string.Join(',',negatives)}");
                }
                 

                return numbersToSum.Sum();
          
        }
    }
}