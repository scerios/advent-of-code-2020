using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_4
{
    public static class DayFour
    {
        public static void PartOne(string[] lines)
        {
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

        public static void PartTwo(string[] lines)
        {
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
    }
}
