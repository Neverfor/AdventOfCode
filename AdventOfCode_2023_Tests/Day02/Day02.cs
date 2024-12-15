using System.Diagnostics;
using AdventOfCode_2023_Tests;
using System.Linq;

namespace AdventOfCode_2023_Tests.Day02
{
    [TestClass]
    public class Day02
    {
        public string currentPath => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, GetType().Name);
        public string InputFileName => GetType().Name + ".txt";
        public string InputFilePath => Path.Combine(currentPath, InputFileName);
        public string OutputFileName => GetType().Name + "_output.txt";
        public string OutputFilePath => Path.Combine(currentPath, OutputFileName);


        [TestInitialize()]
        public void Preset()
        {
            
        }

        [TestMethod]
        public void Puzzle_1()
        {
            var inputLines = File.ReadAllLines(InputFilePath);
            var modifiedLines = new List<int>();

            foreach (var line in inputLines)
            {
                modifiedLines.Add(Logic.GetIdIfGameIsPossible(line));
            }

            var sumOfTheIdsOfAllPossibleGames = modifiedLines.Sum();

            var outputText = $"P1: The sum of all possible games is {sumOfTheIdsOfAllPossibleGames}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

        [TestMethod]
        public void Puzzle_2()
        {
            var inputLines = File.ReadAllLines(InputFilePath);
            var modifiedLines = new List<int>();

            foreach (var line in inputLines)
            {
                modifiedLines.Add(Logic.GetPowerOfMinimumRequiredAmountOfCubesInAGame(line));
            }

            var sumOfTheIdsOfAllPossibleGames = modifiedLines.Sum();

            var outputText = $"P2: The sum of all possible games is {sumOfTheIdsOfAllPossibleGames}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

    }
}