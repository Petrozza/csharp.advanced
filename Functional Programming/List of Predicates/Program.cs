using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();

            List<int> result = new List<int>();

            for (int number = 1; number <= n; number++)
            {
                bool isValid = true;
                
                foreach (var item in dividers)
                {
                    Predicate<int> isDivisible = x => number % x == 0;

                    if (!isDivisible(item))
                    {
                        isValid = false;
                        break;
                    }
 
                }
                if (isValid)
                {
                    result.Add(number);
                } 
            }
            

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
