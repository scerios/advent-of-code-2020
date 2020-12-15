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
            var numbers = ParseInput(text).OrderBy(i => i).ToList();
            var groups = new List<List<int>>();

            var tempList = new List<int>();
            tempList.Add(0);

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i + 1] - numbers[i] == 1)
                {
                    tempList.Add(numbers[i]);
                }
                else
                {
                    tempList.Add(numbers[i]);
                    groups.Add(tempList);
                    tempList = new List<int>();
                }
            }

            var groupCount = new Dictionary<double, double>();

            foreach (List<int> group in groups)
            {
                if (group.Count > 2)
                {
                    if (!groupCount.ContainsKey(group.Count))
                    {
                        groupCount.Add(group.Count, 1);
                    }
                    else
                    {
                        groupCount[group.Count]++;
                    }

                }
            }

            // TODO - Make logic independent of specific variables.

            //var result = 1D;

            //foreach (KeyValuePair<double, double> amount in groupCount)
            //{
            //    Console.WriteLine($"Key: { amount.Key }. Value: { amount.Value }.");
            //}

            //Console.WriteLine(result);

            Console.WriteLine(Math.Pow(2, groupCount[3]) * Math.Pow(4, groupCount[4]) * Math.Pow(7, groupCount[5]));
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

        private static long Factorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
