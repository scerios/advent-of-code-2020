﻿using AdventOfCode.Day_1;
using AdventOfCode.Day_10;
using AdventOfCode.Day_2;
using AdventOfCode.Day_3;
using AdventOfCode.Day_4;
using AdventOfCode.Day_5;
using AdventOfCode.Day_6;
using AdventOfCode.Day_7;
using AdventOfCode.Day_8;
using AdventOfCode.Day_9;
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

            //DaySix.PartOne(GetPuzzleByDayAsStringArray("Day 6"));
            //DaySix.PartTwo(GetPuzzleByDayAsStringArray("Day 6"));

            //DaySeven.PartOne(GetPuzzleByDayAsStringArray("Day 7"));
            //DaySeven.PartTwo(GetPuzzleByDayAsString("Day 7"));

            //DayEight.PartOne(GetPuzzleByDayAsString("Day 8"));
            //DayEight.PartTwo(GetPuzzleByDayAsString("Day 8"));

            //DayNine.PartOne(GetPuzzleByDayAsString("Day 9"));
            //DayNine.PartTwo(GetPuzzleByDayAsString("Day 9"));

            //DayTen.PartOne(GetPuzzleByDayAsString("Day 10"));
            DayTen.PartTwo(GetPuzzleByDayAsString("Day 10"));
        }

        static string[] GetPuzzleByDayAsStringArray(string day)
        {
            return System.IO.File.ReadAllLines(@$"D:\Coding\C#\AdventOfCode\{ day }\puzzle.txt");
        }

        static string GetPuzzleByDayAsString(string day)
        {
            return System.IO.File.ReadAllText(@$"D:\Coding\C#\AdventOfCode\{ day }\puzzle.txt");
        }
    }
}
