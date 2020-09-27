using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = length[0];
            int m = length[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                first.Add(number);
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                second.Add(number);
            }

            foreach (var item in first)
            {
                if (second.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
