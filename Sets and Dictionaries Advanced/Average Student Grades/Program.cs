using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal>());
                }
                dict[name].Add(grade);
            }

            foreach (var pair in dict)
            {
                Console.Write($"{pair.Key} -> ");

                foreach (var item in pair.Value)
                {
                    Console.Write($"{item:f2} ");

                }
                Console.WriteLine($"(avg: {pair.Value.Average():f2})");
            }
        }
    }
}
