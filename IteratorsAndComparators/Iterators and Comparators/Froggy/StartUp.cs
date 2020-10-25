using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake lake = new Lake(stones);
            
            List<int> result = new List<int>();

            foreach (var stone in lake)
            {
                result.Add(stone);
            }
            Console.WriteLine(string.Join(", ", result));
        }


    }
}
