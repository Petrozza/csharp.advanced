using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> SmallestNumber = collection =>
            {
                int minNumber = int.MaxValue;
                foreach (var item in collection)
                {
                    if (item < minNumber)
                    {
                        minNumber = item;
                    }
                }
                return minNumber;
            };
            
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(SmallestNumber(array));
        }
    }
}
