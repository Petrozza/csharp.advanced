using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var numbers = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                
                if (!numbers.ContainsKey(input[i]))
                {
                    numbers.Add(input[i], 0);
                    
                    numbers[input[i]] = 1;
                }
                else
                {
                    
                    numbers[input[i]] += 1;
                }
            }

            foreach (var (key, value) in numbers)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
