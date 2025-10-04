using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp93
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input digits: ");
            string digits = Console.ReadLine();

            foreach (var item in LetterCombinations(digits))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static List<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> map = new Dictionary<char, string> {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };

            if (string.IsNullOrWhiteSpace(digits))
            {
                return new List<string>();
            }

            if (digits.Length > 4)
            {
                Console.WriteLine("length > 4");

                throw new ArgumentException(nameof(digits));
            }

            foreach (char c in digits)
            {
                if (c < '2' || c > '9')
                {
                    Console.WriteLine("2 - 9");

                    throw new KeyNotFoundException(nameof(digits));
                }
            }

            List<string> result = new List<string> { "" };

            foreach (char digit in digits)
            {
                string letters = map[digit];  

                var newResult = new List<string>();  

                foreach (string combination in result)
                {
                    foreach (char letter in letters)
                    {
                        newResult.Add(combination + letter);
                    }
                }

                result = newResult;
            }

            return result;
        }
    }
}
