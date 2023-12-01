using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode_2023_Tests
{
    public static class Shared
    {
        public static void SendOutputToFile(string path, string outputText)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"============Output at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}============");
                sw.WriteLine(outputText);
                sw.WriteLine("============End of output============");
            }
        }

        public static string RemoveCharactersFromString(string inputString)
        {
            Regex rgx = new Regex("[^0-9.]");
            var output = rgx.Replace(inputString, "");
            return output;
        }

        public static int GetFirstAndLastNumberFromString(string inputString)
        {
            //Note, ince ase of a single character, this will return the same character twice, because it will call [0] index twice (Length of 1 minus 1 = 0)
            var firstAndLastCharacters = $"{inputString[0]}{inputString[inputString.Length - 1]}";
            return int.Parse(firstAndLastCharacters);
        }

        public static int GetFirstAndLastNumber(string inputString)
        {
            return GetFirstAndLastNumberFromString(RemoveCharactersFromString(inputString));
        }

        //Note: Initially, I thought it would be sufficient to remove the found string occurances, but using same letter for 2 different words is allowed in this puzzle...
        public static string ConvertSpelledNumbersToNumbers(string inputString)
        {
            var convertedString = inputString;

            foreach (var keyValuePair in spelledNumbersDictionary)
            {
                convertedString = Regex.Replace(convertedString, keyValuePair.Value, keyValuePair.Key.ToString());
            }

            return convertedString;
        }

        public static string ConvertSpelledNumbersToNumbersWithoutRemovingText(string inputString)
        {
            var numbersToInsertAtPosition = new Dictionary<int, int>();

            foreach (var keyValuePair in spelledNumbersDictionary)
            {
                var regex = new Regex(keyValuePair.Value);
                foreach (Match match in regex.Matches(inputString))
                {
                    numbersToInsertAtPosition.Add(match.Index, keyValuePair.Key);
                }
            }

            var convertedString = inputString;
            var addedNumbersCount = 0;

            foreach (var keyValuePair in numbersToInsertAtPosition)
            {
                convertedString = convertedString.Insert(keyValuePair.Key + addedNumbersCount, keyValuePair.Value.ToString());
                addedNumbersCount++;
            }

            return convertedString;
        }

        public static string[] spelledNumbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        public static Dictionary<int, string> spelledNumbersDictionary = new Dictionary<int, string>()
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"}
        };

        public static int GetFirstAndLastNumberWithSpelledNumbers(string inputString)
        {
            return GetFirstAndLastNumberFromString(RemoveCharactersFromString(ConvertSpelledNumbersToNumbersWithoutRemovingText(inputString)));
        }
    }
}
