using System.Diagnostics;
using AdventOfCode_2023_Tests;
using System.Linq;

namespace AdventOfCode_2023_Tests.Day01
{
    [TestClass]
    public class Day01
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
                modifiedLines.Add(Logic.GetFirstAndLastNumber(line));
            }

            var sumOfAllNumbers = modifiedLines.Sum();

            var outputText = $"P1: The sum of all calibration values inside the provided document is {sumOfAllNumbers}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

        [TestMethod]
        public void Puzzle_2()
        {
            var inputLines = File.ReadAllLines(InputFilePath);
            var modifiedLines = new List<int>();

            var counter = 0;
            foreach (var line in inputLines)
            {
                counter++;
                modifiedLines.Add(Logic.GetFirstAndLastNumberWithSpelledNumbers(line));
            }

            var sumOfAllNumbers = modifiedLines.Sum();

            var outputText = $"P2: The sum of all calibration values inside the provided document is {sumOfAllNumbers}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

    }
}