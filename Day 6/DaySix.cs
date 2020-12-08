using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_6
{
    public static class DaySix
    {
        public static void PartOne(string[] lines)
        {
            List<char> charsOfGroup = new List<char>();
            int yesCount = 0;

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    charsOfGroup = charsOfGroup.Select(i => i).Distinct().ToList();
                    yesCount += charsOfGroup.Count;
                    charsOfGroup = new List<char>();

                    continue;
                }

                foreach (char character in line)
                {
                    charsOfGroup.Add(character);
                }
            }

            Console.WriteLine(yesCount);
        }

        public static void PartTwo(string[] lines)
        {
            List<List<char>> charsOfGroup = new List<List<char>>();
            List<char> charsOfPerson = new List<char>();
            int yesCount = 0;
            int personCount = 0;

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    if (personCount == 1)
                    {
                        yesCount += charsOfGroup[0].Count;
                    } 
                    else
                    {
                        foreach (char character in charsOfGroup[0])
                        {
                            bool isFound = false;
                            for (int i = 1; i < personCount; i++)
                            {
                                if (charsOfGroup[i].IndexOf(character) == -1)
                                {
                                    isFound = false;
                                    break;
                                }

                                isFound = true;
                            }

                            if (isFound)
                            {
                                yesCount++;
                            }
                        }
                    }

                    personCount = 0;
                    charsOfPerson = new List<char>();
                    charsOfGroup = new List<List<char>>();

                    continue;
                }

                foreach (char character in line)
                {
                    charsOfPerson.Add(character);
                }

                charsOfGroup.Add(charsOfPerson);
                charsOfPerson = new List<char>();
                personCount++;
            }

            Console.WriteLine(yesCount);
        }
    }
}
