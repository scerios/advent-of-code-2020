using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DayFivePartTwo();
        }

        static string[] GetPuzzleByDayAsStringArray(string day)
        {
            return System.IO.File.ReadAllLines(@$"D:\Coding\C#\AdventOfCode\{ day }\puzzle.txt");
        }

        static void DayOnePartOne()
        {
            bool isFound = false;

            string[] lines = GetPuzzleByDayAsStringArray("Day 1");

            for (int i = 0; i < lines.Length; i++)
            {
                int first = Int32.Parse(lines[i]);

                if (!isFound)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        int second = Int32.Parse(lines[j]);

                        if (j == i)
                        {
                            continue;
                        }

                        if (first + second == 2020)
                        {
                            Console.WriteLine(first * second);
                            isFound = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void DayOnePartTwo()
        {
            bool isFound = false;

            string[] lines = GetPuzzleByDayAsStringArray("Day 1");

            for (int i = 0; i < lines.Length; i++)
            {
                int first = Int32.Parse(lines[i]);

                if (!isFound)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        int second = Int32.Parse(lines[j]);

                        if (!isFound)
                        {
                            if (j == i)
                            {
                                continue;
                            }

                            if (first + second >= 2020)
                            {
                                continue;
                            }
                            else
                            {
                                for (int k = 0; k < lines.Length; k++)
                                {
                                    int third = Int32.Parse(lines[k]);

                                    if (k == i || k == j)
                                    {
                                        continue;
                                    }

                                    if (first + second + third == 2020)
                                    {
                                        Console.WriteLine(first * second * third);
                                        isFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void DayTwoPartOne()
        {
            int validPasswordCount = 0;
            string[] lines = GetPuzzleByDayAsStringArray("Day 2");

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

        static void DayTwoPartTwo()
        {
            int validPasswordCount = 0;
            string[] lines = GetPuzzleByDayAsStringArray("Day 2");

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

        static void DayThreePartOne()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 3");

            Console.WriteLine(HowManyTreesFound(lines, 3, 1));
        }

        static void DayThreePartTwo()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 3");

            long a = HowManyTreesFound(lines, 1, 1);
            long b = HowManyTreesFound(lines, 3, 1);
            long c = HowManyTreesFound(lines, 5, 1);
            long d = HowManyTreesFound(lines, 7, 1);
            long e = HowManyTreesFound(lines, 1, 2);
            Console.WriteLine(a * b * c * d * e);
        }

        static bool IsTreeFound(char character)
        {
            return character == '#';
        }

        static long HowManyTreesFound(string[] lines, int rightStep, int downStep)
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

        static void DayFourPartOne()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 4");
            string[] neededKeys = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            int totalPassports = 0;
            int howManyValidPassports = 0;

            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            Dictionary<string, string> passport = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    passports.Add(passport);
                    totalPassports++;
                    passport = new Dictionary<string, string>();
                    continue;
                }

                string[] details = line.Split(' ');

                foreach (string detail in details)
                {
                    string[] keyValues = detail.Split(':');
                    passport.Add(keyValues[0], keyValues[1]);
                }
            }

            foreach (Dictionary<string, string> pass in passports)
            {
                bool isValid = true;
                foreach (string key in neededKeys)
                {
                    if (!pass.ContainsKey(key))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    howManyValidPassports++;
                }
            }

            Console.WriteLine(howManyValidPassports);
        }

        static void DayFourPartTwo()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 4");
            string[] neededKeys = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            int totalPassports = 0;
            int howManyValidPassports = 0;

            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            Dictionary<string, string> passport = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    passports.Add(passport);
                    totalPassports++;
                    passport = new Dictionary<string, string>();
                    continue;
                }

                string[] details = line.Split(' ');

                foreach (string detail in details)
                {
                    string[] keyValues = detail.Split(':');
                    passport.Add(keyValues[0], keyValues[1]);
                }
            }

            int minBirthYear = 1920;
            int maxBirthYear = 2002;

            int minIssueYear = 2010;
            int maxIssueYear = 2020;

            int minExpirationYear = 2020;
            int maxExpirationYear = 2030;

            int minCmHeight = 150;
            int maxCmHeight = 193;

            int minInHeight = 59;
            int maxInHeight = 76;

            string[] validEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            foreach (Dictionary<string, string> pass in passports)
            {
                bool isValid = true;
                foreach (string key in neededKeys)
                {
                    if (isValid)
                    {
                        if (!pass.ContainsKey(key))
                        {
                            isValid = false;
                            break;
                        }

                        switch (key)
                        {
                            case "byr":
                                int birthYear = Int32.Parse(pass[key]);

                                if (birthYear < minBirthYear || birthYear > maxBirthYear)
                                {
                                    isValid = false;
                                }
                                break;

                            case "iyr":
                                int issueYear = Int32.Parse(pass[key]);

                                if (issueYear < minIssueYear || issueYear > maxIssueYear)
                                {
                                    isValid = false;
                                }
                                break;

                            case "eyr":
                                int expirationYear = Int32.Parse(pass[key]);

                                if (expirationYear < minExpirationYear || expirationYear > maxExpirationYear)
                                {
                                    isValid = false;
                                }
                                break;

                            case "hgt":
                                string type = pass[key].Substring(pass[key].Length - 2);
                                if (type == "")
                                {
                                    isValid = false;
                                    break;
                                }

                                if (pass[key].Length < 3)
                                {
                                    isValid = false;
                                    break;
                                }

                                int height = Int32.Parse(pass[key].Substring(0, pass[key].Length - 2));

                                if (type == "cm")
                                {
                                    if (height < minCmHeight || height > maxCmHeight)
                                    {
                                        isValid = false;
                                    }
                                }
                                else
                                {
                                    if (height < minInHeight || height > maxInHeight)
                                    {
                                        isValid = false;
                                    }
                                }
                                break;

                            case "hcl":
                                string hairColor = pass[key];
                                if (hairColor.Length != 7)
                                {
                                    isValid = false;
                                }
                                break;

                            case "ecl":
                                if (!validEyeColors.Any(pass[key].Contains))
                                {
                                    isValid = false;
                                }
                                break;

                            case "pid":
                                string passportId = pass[key];
                                if (passportId.Length != 9)
                                {
                                    isValid = false;
                                }
                                break;
                        }
                    }

                }

                if (isValid)
                {
                    howManyValidPassports++;
                }
            }

            Console.WriteLine(howManyValidPassports);
        }

        static void DayFivePartOne()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 5");

            double minRow = 0;
            double maxRow = 127.0;
            double minSeat = 0;
            double maxSeat = 7.0;

            int indexer = 0;
            int row = 0;
            int seat = 0;
            int highestSeatId = 0;

            foreach (string line in lines)
            {
                while (indexer < 6)
                {
                    if (line[indexer] == 'F')
                    {
                        maxRow = Math.Floor((minRow + maxRow) / 2);
                        indexer++;
                        continue;
                    }
                    minRow = Math.Ceiling((minRow + maxRow) / 2);
                    
                    indexer++;
                }

                if (line[indexer] == 'F')
                {
                    row = Convert.ToInt32(minRow);
                }
                else
                {
                    row = Convert.ToInt32(maxRow);
                }
                
                indexer++;

                while (indexer < 9)
                {
                    if (line[indexer] == 'L')
                    {
                        maxSeat = Math.Floor((minSeat + maxSeat) / 2);
                        indexer++;
                        continue;
                    }
                    minSeat = Math.Ceiling((minSeat + maxSeat) / 2);

                    indexer++;
                }

                if (line[indexer] == 'L')
                {
                        seat = Convert.ToInt32(minSeat);
                }
                else
                {
                    seat = Convert.ToInt32(maxSeat);
                }
                
                int seatId = row * 8 + seat;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }

                indexer = 0;
                minRow = 0;
                maxRow = 127.0;
                minSeat = 0;
                maxSeat = 7.0;

            }

            Console.WriteLine(highestSeatId);
        }

        static void DayFivePartTwo()
        {
            string[] lines = GetPuzzleByDayAsStringArray("Day 5");

            double minRow = 0;
            double maxRow = 127.0;
            double minSeat = 0;
            double maxSeat = 7.0;

            int indexer = 0;
            int row = 0;
            int seat = 0;
            int mySeatId = 0;
            List<int> seatIds = new List<int>();

            foreach (string line in lines)
            {
                while (indexer < 6)
                {
                    if (line[indexer] == 'F')
                    {
                        maxRow = Math.Floor((minRow + maxRow) / 2);
                        indexer++;
                        continue;
                    }
                    minRow = Math.Ceiling((minRow + maxRow) / 2);

                    indexer++;
                }

                if (line[indexer] == 'F')
                {
                    row = Convert.ToInt32(minRow);
                }
                else
                {
                    row = Convert.ToInt32(maxRow);
                }

                indexer++;

                while (indexer < 9)
                {
                    if (line[indexer] == 'L')
                    {
                        maxSeat = Math.Floor((minSeat + maxSeat) / 2);
                        indexer++;
                        continue;
                    }
                    minSeat = Math.Ceiling((minSeat + maxSeat) / 2);

                    indexer++;
                }

                if (line[indexer] == 'L')
                {
                    seat = Convert.ToInt32(minSeat);
                }
                else
                {
                    seat = Convert.ToInt32(maxSeat);
                }

                int seatId = row * 8 + seat;

                seatIds.Add(seatId);

                indexer = 0;
                minRow = 0;
                maxRow = 127.0;
                minSeat = 0;
                maxSeat = 7.0;

            }

            var ascendingOrder = seatIds.OrderBy(i => i).ToList();

            foreach (int id in ascendingOrder)
            {
                if (!ascendingOrder.Contains(id + 1))
                {
                    if (ascendingOrder.Contains(id + 2))
                    {
                        mySeatId = id + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(mySeatId);
        }
    }
}
