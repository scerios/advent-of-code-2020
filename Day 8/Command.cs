using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day_8
{
    public class Command
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public bool HasRun { get; set; }

        public Command(string name, int value)
        {
            Name = name;
            Value = value;
            HasRun = false;
        }
    }
}
