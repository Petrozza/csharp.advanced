using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> parser = x => int.Parse(x);
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();

            Console.WriteLine(input.Count());
            Console.WriteLine(input.Sum());


        }
    }
}