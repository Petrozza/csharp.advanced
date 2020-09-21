using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> sta = new Queue<int>();
            foreach (int number in arr)
            {
                sta.Enqueue(number);
            }

            var result = new List<int>();
            foreach (int num in sta)
            {
                if (num % 2 == 0)
                {
                    result.Add(num);
                }
            }
            Console.WriteLine(string.Join(", ",result ));
        }
    }
}
