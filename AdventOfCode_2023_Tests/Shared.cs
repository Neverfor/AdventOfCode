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
        
        #region Day 1
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

        #endregion

        #region Day2
        public static List<string> GetASingleWordBeforeEachSearchInput(string inputString, string searchInput, bool includingSearchString = false)
        {
            var foundWords = new List<string>();
            Regex regex = new Regex($"(?:^|\\w+\\s+){searchInput}");

            foreach (Match match in regex.Matches(inputString))
            {
                foundWords.Add(includingSearchString ? match.Value.Replace(" ", "") : match.Value.Replace(searchInput, "").Replace(" ", ""));
            }

            return foundWords;
        }

        public static int MaxAmountOfBlueCubes = 14;
        public static int MaxAmountOfGreenCubes = 13;
        public static int MaxAmountOfRedCubes = 12;

        public static bool IsGamePossible(string inputString)
        {
            var listOfBlues = GetASingleWordBeforeEachSearchInput(inputString, "blue");
            var anyAmountOfBlueCubesLargerThanMaximum = listOfBlues.Where(x => int.Parse(x) > MaxAmountOfBlueCubes);

            var listOfGreens = GetASingleWordBeforeEachSearchInput(inputString, "green");
            var anyAmountOfRedCubesLargerThanMaximum = listOfGreens.Where(x => int.Parse(x) > MaxAmountOfRedCubes);

            var listOfReds = GetASingleWordBeforeEachSearchInput(inputString, "red");
            var anyAmountOfGreenCubesLargerThanMaximum = listOfReds.Where(x => int.Parse(x) > MaxAmountOfGreenCubes);


            if (anyAmountOfBlueCubesLargerThanMaximum.Any() ||
                anyAmountOfRedCubesLargerThanMaximum.Any() ||
                anyAmountOfGreenCubesLargerThanMaximum.Any())
                return false;
            else 
                return true;
        }

        public static int GetGameId(string inputString)
        {
            var foundWords = new List<string>();
            Regex regex = new Regex($"(?<=\\bGame\\s)(\\w+)");

            var match = regex.Matches(inputString).FirstOrDefault();
            return int.Parse(match.Value);
        }

        public static int GetIdIfGameIsPossible (string inputString)
        {
            if(IsGamePossible(inputString))
            {
                return GetGameId(inputString);
            }
            return 0;
        }

        public static int GetMinimumAmountOfCubesPerColor(string inputString, string cubesColor)
        {
            var listOfBlues = GetASingleWordBeforeEachSearchInput(inputString, cubesColor);
            var anyAmountOfBlueCubesLargerThanMaximum = listOfBlues.Any() ? listOfBlues.Max(x => int.Parse(x)) : 0;

            //we want a power of all possible cubes, hence return 1 in place of 0, so that the multiplication will work and the result won't be affected
            return anyAmountOfBlueCubesLargerThanMaximum == 0 ? 1 : anyAmountOfBlueCubesLargerThanMaximum;
        }

        public static int GetPowerOfMinimumRequiredAmountOfCubesInAGame(string inputString)
        {
            return GetMinimumAmountOfCubesPerColor(inputString, "blue") * GetMinimumAmountOfCubesPerColor(inputString, "red") * GetMinimumAmountOfCubesPerColor(inputString, "green");
        }

        #endregion

    }
}
