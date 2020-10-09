using System;
using System.Linq;

namespace Sort_00Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(x => int.Parse(x))
                .Where(y => y % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", input));


        }
    }
}