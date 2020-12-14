using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_10
{
    public static class DayTen
    {
        public static void PartOne(string text)
        {
            var numbers = ParseInput(text).OrderBy(i => i).ToList();
            var oneJolt = 0;
            var threeJolts = 0;

            if (numbers[0] == 1)
            {
                oneJolt++;
            }
            else if (numbers[0] == 3)
            {
                threeJolts++;
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] + 1 == numbers[i + 1])
                {
                    oneJolt++;
                    continue;
                }

                threeJolts++;
            }

            threeJolts++;

            Console.WriteLine(oneJolt * threeJolts);
        }

        public static void PartTwo(string text)
        {

        }

        private static List<int> ParseInput(string text)
            => text
                .Split(Environment.NewLine)
                .Where(line => line.Length > 0)
                .Select(ParseInt)
                .ToList();

        private static int ParseInt(string line)
        {
            return Int32.Parse(line);
        }
    }
}
