using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumpsData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(pumpsData);
            }

            int index = 0;
            while (true)
            {
                int fuelAmmount = 0;
                bool foundPoint = true;

                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = pumps.Dequeue();
                    fuelAmmount += currentPump[0];

                    if (fuelAmmount < currentPump[1])
                    {
                        foundPoint = false;
                    }

                    fuelAmmount -= currentPump[1];
                    pumps.Enqueue(currentPump);
                }

                if (foundPoint)
                {
                    break;
                }

                index++;

                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(index);
        }
    }
}
