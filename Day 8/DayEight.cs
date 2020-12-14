using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_8
{
    public static class DayEight
    {
        public static int Accumulator { get; set; }
        public static int CommandIndex { get; set; }
        public static int OccurenceCount { get; set; }
        public static int ChangeCount { get; set; }
        public static List<Command> Commands { get; set; }
        public static Command CurrentCommand { get; set; }

        public static void PartOne(string text)
        {
            Accumulator = 0;
            CommandIndex = 0;
            Commands = ParseInput(text);
            CurrentCommand = Commands[CommandIndex];
            
            while (!CurrentCommand.HasRun)
            {
                CurrentCommand.HasRun = true;

                if (CurrentCommand.Name == "nop")
                {
                    CommandIndex++;
                    CurrentCommand = Commands[CommandIndex];
                    continue;
                }

                if (CurrentCommand.Name == "acc")
                {
                    Accumulator += CurrentCommand.Value;
                    CommandIndex++;
                    CurrentCommand = Commands[CommandIndex];
                    continue;
                }
                
                if (CurrentCommand.Name == "jmp")
                {
                    CommandIndex += CurrentCommand.Value;
                    CurrentCommand = Commands[CommandIndex];
                    continue;
                }

            }

            Console.WriteLine(Accumulator);
        }

        public static void PartTwo(string text)
        {
            Accumulator = 0;
            CommandIndex = 0;
            ChangeCount = 1;
            OccurenceCount = 0;
            Commands = ParseInput(text);
            CurrentCommand = Commands[CommandIndex];

            while (true)
            {
                if (CurrentCommand.HasRun)
                {
                    Reset();
                    continue;
                }

                if (CommandIndex == Commands.Count)
                {
                    break;
                }

                CurrentCommand.HasRun = true;

                if (CurrentCommand.Name == "nop")
                {
                    OccurenceCount++;

                    if (OccurenceCount == ChangeCount)
                    {
                        CommandIndex += CurrentCommand.Value;
                        if (CommandIndex < 0 || CommandIndex > Commands.Count)
                        {
                            Reset();
                            continue;
                        }
                        CurrentCommand = Commands[CommandIndex];
                    }
                    else
                    {
                        Jump();
                    }

                    continue;
                }

                if (CurrentCommand.Name == "acc")
                {
                    Accumulator += CurrentCommand.Value;
                    CommandIndex++;
                    CurrentCommand = Commands[CommandIndex];
                    continue;
                }

                if (CurrentCommand.Name == "jmp")
                {
                    OccurenceCount++;

                    if (OccurenceCount == ChangeCount)
                    {
                        Jump();
                    }
                    else
                    {
                        CommandIndex += CurrentCommand.Value;
                        if (CommandIndex < 0 || CommandIndex > Commands.Count)
                        {
                            Reset();
                            continue;
                        }

                        if (CommandIndex == Commands.Count)
                        {
                            break;
                        }

                        CurrentCommand = Commands[CommandIndex];
                    }

                    continue;
                }
            }

            Console.WriteLine(Accumulator);
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

        private static void Reset()
        {
            Accumulator = 0;
            CommandIndex = 0;
            OccurenceCount = 0;
            ChangeCount++;
            Commands.ForEach(command => command.HasRun = false);
            CurrentCommand = Commands[CommandIndex];
        }

        private static void Jump()
        {
            CommandIndex++;
            CurrentCommand = Commands[CommandIndex];
        }
    }
}
