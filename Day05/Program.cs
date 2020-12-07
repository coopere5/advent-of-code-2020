using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day05
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

            var input = File.ReadAllLines("manipinput.txt");    //todo: do this without manipulated input

            int max = 0;
            foreach (var line in input)
            {
                var split = line.Split(' ');
                max = Math.Max(max, Convert.ToInt32(split[0], 2) * 8 + Convert.ToInt32(split[1], 2));
            }

            Console.WriteLine($"Part 1: {max}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("manipinput.txt");    //todo: do this without manipulated input
            var exists = new List<int>();

            int max = 0;
            foreach (var line in input)
            {
                var split = line.Split(' ');
                var ID = Convert.ToInt32(split[0], 2) * 8 + Convert.ToInt32(split[1], 2);
                max = Math.Max(max, ID);
                exists.Add(ID);
            }

            var all = Enumerable.Range(0, max);
            var except = all.Except(exists);

            Console.WriteLine($"Part 2: ");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
