using System;
using System.Diagnostics;
using System.IO;

namespace Day12
{
    internal class Program
    {
        private static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");

            sw.Stop();
            Console.WriteLine($"Part 1: ");
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");

            sw.Stop();
            Console.WriteLine($"Part 2: ");
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
