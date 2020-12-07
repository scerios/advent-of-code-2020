using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //DayOne.PartOne(GetPuzzleByDayAsStringArray("Day 1"));
            //DayOne.PartTwo(GetPuzzleByDayAsStringArray("Day 1"));

            //DayTwo.PartOne(GetPuzzleByDayAsStringArray("Day 2"));
            //DayTwo.PartTwo(GetPuzzleByDayAsStringArray("Day 2"));

            //DayThree.PartOne(GetPuzzleByDayAsStringArray("Day 3"));
            //DayThree.PartTwo(GetPuzzleByDayAsStringArray("Day 3"));

            //DayFour.PartOne(GetPuzzleByDayAsStringArray("Day 4"));
            //DayFour.PartTwo(GetPuzzleByDayAsStringArray("Day 5"));

            //DayFive.PartOne(GetPuzzleByDayAsStringArray("Day 5"));
            //DayFive.PartTwo(GetPuzzleByDayAsStringArray("Day 5"));
        }

        static string[] GetPuzzleByDayAsStringArray(string day)
        {
            return System.IO.File.ReadAllLines(@$"D:\Coding\C#\AdventOfCode\{ day }\puzzle.txt");
        }
    }
}
