using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day08
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

            Dictionary<int, KeyValuePair<string, int>> dict = new Dictionary<int, KeyValuePair<string, int>>();
            var i = 0;
            foreach (var line in input)
            {
                var split = line.Split(' ');
                dict.Add(i++, new KeyValuePair<string, int>(split[0], int.Parse(split[1])));
            }

            var acc = 0;
            var idx = 0;

            HashSet<int> set = new HashSet<int>();
            set.Add(idx);
            var running = true;

            while (running)
            {
                ProcessNext(dict, ref acc, ref idx);
                running = set.Add(idx);
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {acc}");
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

        private static void ProcessNext(Dictionary<int, KeyValuePair<string, int>> dict, ref int acc, ref int idx)
        {
            switch (dict[idx].Key)
            {
                case "acc":
                    acc += dict[idx].Value;
                    idx++;
                    break;
                case "jmp":
                    idx += dict[idx].Value;
                    break;
                case "nop":
                    idx++;
                    break;
            }
        }
    }
}
