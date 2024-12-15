using AdventOfCode_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024_Tests.Day01
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

            var leftNumbersList = new List<int>();
            var rightNumbersList = new List<int>();

            var listWithCombinedDistances = new List<int>();

            foreach (var line in inputLines)
            {
                var numbers = Logic.ConvertRowToNumbers(line);
                leftNumbersList.Add(numbers[0]);
                rightNumbersList.Add(numbers[1]);
            }

            leftNumbersList = leftNumbersList.OrderBy(x => x).ToList();
            rightNumbersList = rightNumbersList.OrderBy(x => x).ToList();

            var index = 0;
            foreach (var nr in leftNumbersList)
            {
                listWithCombinedDistances.Add(Logic.MeasureDistance(leftNumbersList[index], rightNumbersList[index]));
                index++;
            }

            var sumOfAllNumbers = listWithCombinedDistances.Sum();

            var outputText = $"Day01 Part1: The sum of all distances inside the provided document is {sumOfAllNumbers}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

        [TestMethod]
        public void Puzzle_2()
        {
            var inputLines = File.ReadAllLines(InputFilePath);

            var leftNumbersList = new List<int>();
            var rightNumbersList = new List<int>();

            var listWithSimilarDistances = new List<int>();

            foreach (var line in inputLines)
            {
                var numbers = Logic.ConvertRowToNumbers(line);
                leftNumbersList.Add(numbers[0]);
                rightNumbersList.Add(numbers[1]);
            }

            leftNumbersList = leftNumbersList.OrderBy(x => x).ToList();
            rightNumbersList = rightNumbersList.OrderBy(x => x).ToList();

            foreach (var nr in leftNumbersList)
            {
                listWithSimilarDistances.Add(Logic.MeasureSimilarity(nr, rightNumbersList));
            }

            var sumOfAllNumbers = listWithSimilarDistances.Sum();

            var outputText = $"Day01 Part2: The sum of all similar distances inside the provided document is {sumOfAllNumbers}";
            Debug.WriteLine(outputText);
            Shared.SendOutputToFile(OutputFilePath, outputText);
        }

    }
}
