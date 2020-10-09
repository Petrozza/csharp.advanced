using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> comparator = new Func<int, int, int>((x, y) =>
           {
               if (x % 2 == 0 && y % 2 != 0)
               {
                   return -1;
               }
               if (x % 2 !=0 && y % 2 == 0)
               {
                   return 1;
               }
               else
               {
                   return x.CompareTo(y);
               }
           });

            Comparison<int> comparison = new Comparison<int>(comparator);

            Array.Sort(numbers, comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
