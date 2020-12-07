using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day06
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

            var input = File.ReadAllText("input.txt");
            var splitInput = input.Split("\r\n\r\n");
            var total = 0;
            foreach (var group in splitInput)
            {
                var splitGroup = group.Split("\r\n");
                var all = new List<char>();
                foreach (var line in splitGroup)
                {
                    all = all.Union(line.ToCharArray()).ToList();
                }
                total += all.Count;
            }

            Console.WriteLine($"Part 1: {total}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllText("input.txt");
            var splitInput = input.Split("\r\n\r\n");
            var total = 0;
            foreach (var group in splitInput)
            {
                var splitGroup = group.Split("\r\n");
                var all = "abcdefghijklmnopqrstuvwxyz".ToList();
                foreach (var line in splitGroup)
                {
                    all = all.Intersect(line.ToCharArray()).ToList();
                }
                total += all.Count;
            }

            Console.WriteLine($"Part 2: {total}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
