using System;
using System.Diagnostics;
using System.IO;

namespace Day03
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

            var trees = CheckSlope(3, 1, input);
            Console.WriteLine($"Part 1: {trees}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");

            long product = CheckSlope(1, 1, input) * CheckSlope(3, 1, input) * CheckSlope(5, 1, input) * CheckSlope(7, 1, input) * CheckSlope(1, 2, input);
            Console.WriteLine($"Part 2: {product}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static long CheckSlope(int right, int down, string[] input)
        {
            var x = 0;
            var y = 0;

            var trees = 0;
            while (y < input.Length)
            {
                if (input[y][x] == '#') trees++;
                x += right;
                y += down;
                x %= input[0].Length;
            }

            return trees;
        }
    }
}
