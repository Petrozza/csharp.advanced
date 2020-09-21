using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
           
            Stack<int> clothes = new Stack<int>(seq);

            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = rackCapacity;

            int countRack = 1;

            while (clothes.Any())
            {
                int currentClothes = clothes.Peek();

                if (currentRackCapacity >= currentClothes)
                {
                    currentRackCapacity -= currentClothes;
                    clothes.Pop();
                }
                else
                {
                    countRack++;
                    currentRackCapacity = rackCapacity;
                }

            }
            Console.WriteLine(countRack);
        }
    }
}
