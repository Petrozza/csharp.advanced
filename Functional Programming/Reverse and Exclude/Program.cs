using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();
            
            Func<int, bool> predicate = x => x % n != 0;
           
            Action<List<int>> Print = msg => Console.WriteLine(string.Join(" ", msg));
            
            numbers = numbers.Where(predicate).ToList();
            Print(numbers);
        }
    }
}
