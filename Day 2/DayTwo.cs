using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayTwo
    {
        public static void PartOne(string[] lines)
        {
            int validPasswordCount = 0;

            foreach (string line in lines)
            {
                int occurenceCount = 0;
                string[] parts = line.Split(' ');
                string[] occurrences = parts[0].Split('-');
                int minOccurrence = Int32.Parse(occurrences[0]);
                int maxOccurrence = Int32.Parse(occurrences[1]);

                char neededCharacter = Char.Parse(parts[1].Substring(0, 1));

                foreach (char character in parts[2])
                {
                    if (character == neededCharacter)
                    {
                        occurenceCount++;
                    }
                }

                if (occurenceCount >= minOccurrence && occurenceCount <= maxOccurrence)
                {
                    validPasswordCount++;
                }
            }

            Console.WriteLine(validPasswordCount);
        }

        public static void PartTwo(string[] lines)
        {
            int validPasswordCount = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string[] occurrences = parts[0].Split('-');
                string password = parts[2];
                int firstOccurrence = Int32.Parse(occurrences[0]) - 1;
                int secondOccurrence = Int32.Parse(occurrences[1]) - 1;

                char neededCharacter = Char.Parse(parts[1].Substring(0, 1));

                if (password[firstOccurrence] == neededCharacter)
                {
                    if (password[secondOccurrence] != neededCharacter)
                    {
                        validPasswordCount++;
                    }

                }
                else if (password[secondOccurrence] == neededCharacter)
                {
                    validPasswordCount++;
                }


            }

            Console.WriteLine(validPasswordCount);
        }
    }
}
