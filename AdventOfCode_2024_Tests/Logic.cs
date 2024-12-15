using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode_2024_Tests
{
    public static class Logic
    {
        #region Day01
        public static int ToPositive(this int number)
        {
            return number >= 0 ? number : -1 * number;
        }

        public static int MeasureDistance(int number1, int number2)
        {
            return (number1 - number2).ToPositive();
        }

        public static int[] ConvertRowToNumbers (this string inputString)
        {
            return inputString.Split("   ").Select(int.Parse).ToArray();
        }

        public static int MeasureSimilarity(this int number, List<int> listToAnalyse)
        {
            var sameNumbers = listToAnalyse.Where(x => x == number).ToArray();
            return sameNumbers.Any() ? number * sameNumbers.Count() : 0;
        }

        #endregion

        #region Day02
        #endregion

        #region Day03
        #endregion

        #region Day04
        #endregion

        #region Day05
        #endregion
    }
}
        