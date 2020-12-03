using System;
using System.Diagnostics;
using System.IO;

namespace Day04
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

            Console.WriteLine($"Part 1: ");

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
