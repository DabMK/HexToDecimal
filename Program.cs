using System;
using System.Reflection;

namespace HexToDecimal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string input = args[0];
                if (input.Contains(' '))
                {
                    input = input.Replace("    ", " ");
                    string result = string.Empty;
                    foreach (string data in input.Split(' '))
                    {
                        result += TotalSum(data) + " ";
                    }
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(TotalSum(input));
                }
            }
            else
            {
                Console.WriteLine("Usage: \"HexToDecimal <string>\" (all of the invalid characters will be considered \"0\")");
            }
        }

        private static double TotalSum(string input)
        {
            int index = input.Length - 1;
            double totalSum = 0;
            foreach (char c in input)
            {
                int sum = 0;
                if (int.TryParse(c.ToString(), out _))
                {
                    sum = int.Parse(c.ToString());
                }
                else if (char.IsLetter(c))
                {
                    switch (c.ToString().ToLower())
                    {
                        case "a": sum = 10; break;
                        case "b": sum = 11; break;
                        case "c": sum = 12; break;
                        case "d": sum = 13; break;
                        case "e": sum = 14; break;
                        case "f": sum = 15; break;
                    }
                }
                totalSum += sum * Math.Pow(16, index);
                index--;
            }
            return totalSum;
        }
    }
}