using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class DayOne
    {
        public static void PartOne(string[] lines)
        {
            bool isFound = false;

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

        public static void PartTwo(string[] lines)
        {
            bool isFound = false;

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
    }
}
