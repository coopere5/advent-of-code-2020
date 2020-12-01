using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day1
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

            var input = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if(input[i] + input[j] == 2020)
                    {
                        Console.WriteLine($"Part 1: {i * j}");

                        sw.Stop();
                        Debug.WriteLine(sw.Elapsed);
                        return;
                    }
                }
            }
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
