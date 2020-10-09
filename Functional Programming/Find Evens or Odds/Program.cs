using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Predicate<int> predicateEven = n => n % 2 == 0;

            List<int> numbers = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                numbers.Add(i);
            }

            string numberType = Console.ReadLine();

            List<int> result = new List<int>();

            if (numberType == "even")
            {
                result = numbers.FindAll(x => predicateEven(x));
            }
            else
            {
                result = numbers.FindAll(x => !predicateEven(x));
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
