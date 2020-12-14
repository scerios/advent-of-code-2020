using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_9
{
    public static class DayNine
    {
        public static void PartOne(string text)
        {
            List<long> numbers = ParseInput(text);

            for (int i = 25; i < numbers.Count; i++)
            {
                var isFound = false;
                var target = numbers[i];

                for (int j = 1; j <= 25; j++)
                {
                    var numberA = numbers[i - j];

                    for (int k = 1; k <= 25; k++)
                    {
                        var numberB = numbers[i - k];

                        if (j == k)
                        {
                            continue;
                        }

                        if (target == numberA + numberB)
                        {
                            isFound = true;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine(target);
                    break;
                }
            }
        }

        public static void PartTwo(string text)
        {
            List<long> numbers = ParseInput(text);

            var target = 1124361034L;
            var minIndex = 0;
            var maxIndex = 0;

            while (true)
            {
                target -= numbers[maxIndex];

                if (target == 0)
                {
                    var subList = numbers.GetRange(minIndex, maxIndex - minIndex);

                    Console.WriteLine(subList.Min() + subList.Max());
                    break;
                }

                maxIndex++;

                if (target < 0)
                {
                    minIndex++;
                    maxIndex = minIndex;
                    target = 1124361034L;
                }
            }
        }

        private static List<long> ParseInput(string text)
            => text
                .Split(Environment.NewLine)
                .Where(line => line.Length > 0)
                .Select(ParseInt)
                .ToList();

        private static long ParseInt(string line)
        {
            return Int64.Parse(line);
        }
    }
}
