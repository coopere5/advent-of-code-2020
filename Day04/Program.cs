using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

            var passports = new List<Passport>();
            passports.Add(new Passport());
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(new Passport());
                }
                else
                {
                    var tokens = line.Split(' ');
                    foreach (var token in tokens)
                    {
                        passports.Last().ProcessInput(token);
                    }
                }
            }

            var valid = passports.Count(p => p.RequiredFieldsFilled());

            Console.WriteLine($"Part 1: {valid}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }

        private static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");

            var passports = new List<Passport>();
            passports.Add(new Passport());
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(new Passport());
                }
                else
                {
                    var tokens = line.Split(' ');
                    foreach (var token in tokens)
                    {
                        passports.Last().ProcessInput(token);
                    }
                }
            }

            var valid = passports.Count(p => p.IsValid());

            Console.WriteLine($"Part 2: {valid}");

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }

    internal class Passport
    {
        public string BirthYear;
        public string IssueYear;
        public string ExpirationYear;
        public string Height;
        public string HairColor;
        public string EyeColor;
        public string PassportID;
        public string CountryID;

        public void ProcessInput(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    BirthYear = value;
                    break;
                case "iyr":
                    IssueYear = value;
                    break;
                case "eyr":
                    ExpirationYear = value;
                    break;
                case "hgt":
                    Height = value;
                    break;
                case "hcl":
                    HairColor = value;
                    break;
                case "ecl":
                    EyeColor = value;
                    break;
                case "pid":
                    PassportID = value;
                    break;
                case "cid":
                    CountryID = value;
                    break;
                default:
                    throw new Exception("Invalid key: " + key);
            }
        }

        public void ProcessInput(string kvp)
        {
            var split = kvp.Split(':');
            ProcessInput(split[0], split[1]);
        }

        public bool RequiredFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(BirthYear) ||
                string.IsNullOrWhiteSpace(IssueYear) ||
                string.IsNullOrWhiteSpace(ExpirationYear) ||
                string.IsNullOrWhiteSpace(Height) ||
                string.IsNullOrWhiteSpace(HairColor) ||
                string.IsNullOrWhiteSpace(EyeColor) ||
                string.IsNullOrWhiteSpace(PassportID))
            {
                return false;
            }
            return true;
        }

        public bool RequiredFieldsValid()
        {
            int parsed;
            // byr (Birth Year) - four digits; at least 1920 and at most 2002.
            if (int.TryParse(BirthYear, out parsed))
            {
                if (parsed < 1920 || parsed > 2002) return false;
            }
            else
            {
                return false;
            }

            // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            if (int.TryParse(IssueYear, out parsed))
            {
                if (parsed < 2010 || parsed > 2020) return false;
            }
            else
            {
                return false;
            }

            // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            if (int.TryParse(IssueYear, out parsed))
            {
                if (parsed < 2020 || parsed > 2030) return false;
            }
            else
            {
                return false;
            }

            // hgt (Height) - a number followed by either cm or in:
            // If cm, the number must be at least 150 and at most 193.
            // If in, the number must be at least 59 and at most 76.
            if (!Regex.IsMatch(Height, "^([0-9]*)(cm|in)$")) return false;
            var heightGroups = Regex.Match(Height, "^([0-9]*)(cm|in)$").Groups;
            if (!int.TryParse(heightGroups[0].ToString(), out parsed)) return false;
            switch (heightGroups[1].ToString())
            {
                case "cm":
                    if (parsed < 150 || parsed > 193) return false;
                    break;
                case "in":
                    if (parsed < 59 || parsed > 76) return false;
                    break;
                default:
                    throw new Exception("Unexpected input " + heightGroups[1]);
            }


            // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            if (!Regex.IsMatch(HairColor, "^#[a-fA-F0-9]{6}$")) return false;

            // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            if (!Array.Exists(new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }, element => element == EyeColor)) return false;

            // pid (Passport ID) - a nine-digit number, including leading zeroes.
            if (PassportID.Length != 9 || !int.TryParse(PassportID, out parsed)) return false;

            return true;
        }

        public bool IsValid()
        {
            return RequiredFieldsFilled() && RequiredFieldsValid();
        }
    }
}
