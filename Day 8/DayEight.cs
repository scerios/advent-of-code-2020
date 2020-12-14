using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_8
{
    public static class DayEight
    {
        public static void PartOne(string text)
        {
            int accumulator = 0;
            int commandIndex = 0;
            var commands = ParseInput(text);
            var currentCommand = commands[commandIndex];
            
            while (!currentCommand.HasRun)
            {
                currentCommand.HasRun = true;

                if (currentCommand.Name == "nop")
                {
                    commandIndex++;
                    currentCommand = commands[commandIndex];
                    continue;
                }

                if (currentCommand.Name == "acc")
                {
                    accumulator += currentCommand.Value;
                    commandIndex++;
                    currentCommand = commands[commandIndex];
                    continue;
                }
                
                if (currentCommand.Name == "jmp")
                {
                    commandIndex += currentCommand.Value;
                    currentCommand = commands[commandIndex];
                    continue;
                }

            }

            Console.WriteLine(accumulator);
        }

        private static List<Command> ParseInput(string text)
            => text
                .Split(Environment.NewLine)
                .Where(line => line.Length > 0)
                .Select(ParseCommand)
                .ToList();

        private static Command ParseCommand(string line)
        {
            var parts = line.Split(' ');

            return new Command(parts[0], Int32.Parse(parts[1]));
        }
    }
}
