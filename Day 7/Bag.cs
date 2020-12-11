using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_7
{
    public class Bag
    {
        public int Amount { get; set; }
        public string Name { get; set; }

        public Bag(string name, int amount = 1)
        {
            Amount = amount;
            Name = name;
        }
    }
}
