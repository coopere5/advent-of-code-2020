using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day07
{
    internal class Program
    {
        private static void Main()
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");
            var dict = new Dictionary<string, string>();
            var set = new HashSet<string>();
            set.Add("shiny gold");
            foreach (var line in input)
            {
                var split = line.Split(" bags contain ");
                dict.Add(split[0], split[1]);
            }

            var running = true;
            while (running)
            {
                running = false;
                foreach (var rule in dict)
                {
                    foreach (var entry in set)
                    {
                        if (rule.Value.Contains(entry))
                        {
                            if (set.Add(rule.Key)) running = true;
                            break;
                        }
                    }
                }
            }

            sw.Stop();

            Console.WriteLine($"Part 1: {set.Count - 1}");
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");
            var dict = new Dictionary<string, Dictionary<string, int>>();

            foreach (var line in input)
            {
                var split = line.Split(" bags contain ");
                var matches = Regex.Matches(split[1], @"([0-9]+) (\w+ \w+) bags?");
                var contains = new Dictionary<string, int>();
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;
                    contains.Add(groups[2].ToString(), int.Parse(groups[1].ToString()));
                }
                dict.Add(split[0], contains);
            }

            var total = CheckBag(dict, "shiny gold", 1);

            sw.Stop();

            Console.WriteLine($"Part 2: {total}");
            Debug.WriteLine(sw.Elapsed);
        }

        private static int CheckBag(Dictionary<string, Dictionary<string, int>> dict, string bag, int count)
        {
            int total = 0;
            var contains = dict[bag];
            total += contains.Values.Sum() * count;
            foreach (var item in contains)
            {
                total += CheckBag(dict, item.Key, item.Value) * count;
            }
            return total;
        }
    }
}
