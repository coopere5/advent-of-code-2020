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
                    if (input[i] + input[j] == 2020)
                    {
                        Console.WriteLine($"Part 1: {input[i] * input[j]}");

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

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    for (int k = j; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            Console.WriteLine($"Part 2: {input[i] * input[j] * input[k]}");

                            sw.Stop();
                            Debug.WriteLine(sw.Elapsed);
                            return;
                        }
                    }

                }
            }
        }
    }
}
