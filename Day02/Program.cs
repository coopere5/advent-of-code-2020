using System;
using System.Diagnostics;
using System.IO;

namespace Day02
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
            var total = 0;

            foreach (var line in input)
            {
                var split = line.Split('-', ' ', ':');

                var lower = int.Parse(split[0]);
                var upper = int.Parse(split[1]);
                var letter = split[2][0];
                var password = split[4];

                var count = 0;

                foreach (var c in password)
                {
                    if (c == letter)
                    {
                        count++;
                        if (count > upper) continue;
                    }
                }
                if (count >= lower && count <= upper) total++;
            }

            Console.WriteLine($"Part 1: {total}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");
            var total = 0;

            foreach (var line in input)
            {
                var split = line.Split('-', ' ', ':');
                
                var i = int.Parse(split[0]) - 1;
                var j = int.Parse(split[1]) - 1;
                var letter = split[2][0];
                var password = split[4];

                if (password[i] == letter ^ password[j] == letter) total++;
            }

            Console.WriteLine($"Part 2: {total}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
