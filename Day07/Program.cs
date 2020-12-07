using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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

            Console.WriteLine($"Part 1: {set.Count - 1}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");

            Console.WriteLine($"Part 2: ");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
