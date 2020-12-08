using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day_3
{
    public static class DayThree
    {
        public static void PartOne(string[] lines)
        {
            Console.WriteLine(HowManyTreesFound(lines, 3, 1));
        }

        public static void PartTwo(string[] lines)
        {
            long a = HowManyTreesFound(lines, 1, 1);
            long b = HowManyTreesFound(lines, 3, 1);
            long c = HowManyTreesFound(lines, 5, 1);
            long d = HowManyTreesFound(lines, 7, 1);
            long e = HowManyTreesFound(lines, 1, 2);
            Console.WriteLine(a * b * c * d * e);
        }
        private static long HowManyTreesFound(string[] lines, int rightStep, int downStep)
        {
            long howManyTrees = 0;
            int index = 0;
            int lineLength = lines[0].Length;
            int startIndexOnNewLine = rightStep - lineLength % rightStep;

            for (int i = 0; i < lines.Length; i += downStep)
            {
                if (lineLength > index)
                {
                    howManyTrees += IsTreeFound(lines[i][index]) ? 1 : 0;
                    index += rightStep;

                    if (index >= lineLength)
                    {
                        startIndexOnNewLine = index - lineLength;
                    }
                }
                else
                {
                    index = startIndexOnNewLine;

                    howManyTrees += IsTreeFound(lines[i][index]) ? 1 : 0;
                    index += rightStep;
                }
            }

            return howManyTrees;
        }

        private static bool IsTreeFound(char character)
        {
            return character == '#';
        }
    }
}
