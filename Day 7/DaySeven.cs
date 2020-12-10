using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_7
{
    public static class DaySeven
    {
        public static void PartOne(string[] lines)
        {
            List<string> bags = new List<string>() { "shiny gold" };
            List<string> allBags = new List<string>();
            List<string> searchBags;

            bool isFound = true;

            while (isFound)
            {
                searchBags = bags;
                bags = new List<string>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(" bags contain ");

                    if (parts[1] == "no other bags.")
                    {
                        continue;
                    }

                    List<string> children = parts[1].Split(',').ToList();

                    foreach (string bag in searchBags)
                    {
                        if (children.Any(c => c.Contains(bag)))
                        {
                            bags.Add(parts[0]);
                            allBags.Add(parts[0]);
                            break;
                        }
                    }
                }

                if (bags.Count == 0)
                {
                    isFound = false;
                }
            }

            Console.WriteLine(allBags.Select(i => i).Distinct().ToList().Count);
        }

        public static void PartTwo(string[] lines)
        {

        }
    }
}
