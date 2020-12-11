using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_7
{
    public static class DaySeven
    {
        private static readonly string _target = "shiny gold";
        private static readonly string _separator = " bags contain ";
        private static readonly string _noMoreBag = "no other bags.";

        public static void PartOne(string[] lines)
        {
            List<string> bags = new List<string>() { _target };
            List<string> allBags = new List<string>();
            List<string> searchBags;

            bool isFound = true;

            while (isFound)
            {
                searchBags = bags;
                bags = new List<string>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(_separator);

                    if (parts[1] == _noMoreBag)
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

        public static void PartTwo(string text)
        {
            Console.WriteLine(Solve(ParseInput(text)));
        }

        public static Dictionary<string, Node<Bag>> ParseInput(string text)
            => text
                .Split(Environment.NewLine)
                .Where(line => line.Length > 0)
                .Select(ParseBagDescription)
                .ToDictionary(node => node.Name, node => node);

        private static Node<Bag> ParseBagDescription(string description)
        {
            var parts = description.Split(_separator);
            var name = parts[0];

            var node = new Node<Bag>(name, new Bag(name));

            var innerBagNodes = parts[1]
                .Split(',')
                .Where(description => description != _noMoreBag)
                .Select(bag => bag.TrimStart())
                .Select(bag => ParseBagContents(bag))
                .Select(bag => new Node<Bag>(bag.Name, bag)).ToList();

            node.AddChildren(innerBagNodes);

            return node;
        }

        private static Bag ParseBagContents(string contents)
        {
            var space = contents.IndexOf(' ');
            var name = contents[(space + 1)..contents.LastIndexOf(' ')];
            Int32.TryParse(contents[..space], out int count);

            return new Bag(name, count);
        }

        private static long Solve(Dictionary<string, Node<Bag>> input)
            => CountInnerBagsRecursive(input, input[_target]) - 1;

        private static long CountInnerBagsRecursive(Dictionary<string, Node<Bag>> allNodes, Node<Bag> node)
            => node.Children.Aggregate(1L, (sum, current) =>
                sum += current.Value.Amount * CountInnerBagsRecursive(allNodes, allNodes[current.Name]));
    }
}
