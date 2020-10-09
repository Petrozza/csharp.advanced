using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] beeTerritory = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;
            int pollinatedFlowers = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    beeTerritory[row, col] = input[col];
                    
                    if (input[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = string.Empty;
            while (true)
            {
                if (beeTerritory[beeRow, beeCol] != 'O')
                {
                    command = Console.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }
                }

                beeTerritory[beeRow, beeCol] = '.';

                if (command == "up")
                {
                    beeRow -= 1;
                }

                else if (command == "down")
                {
                    beeRow += 1;
                }

                else if (command == "left")
                {
                    beeCol -= 1;
                }

                else if (command == "right")
                {
                    beeCol += 1;
                }

                else if (command == "End")
                {
                    break;
                }

                if (beeRow < 0 || beeRow >= n || beeCol < 0 || beeCol >= n )
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (beeTerritory[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }

                if (beeTerritory[beeRow, beeCol] == 'O')
                {
                    continue;
                }

                beeTerritory[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(beeTerritory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
