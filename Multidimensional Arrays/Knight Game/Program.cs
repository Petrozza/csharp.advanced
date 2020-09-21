using System;
using System.Diagnostics.Tracing;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chess = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    chess[row, col] = input[col];
                }
            }

            int[] indexes = new int[]
            {
                1, 2,
                1, -2,
                -1, 2,
                -1, -2,
                2, 1,
                2, -1,
                -2, 1,
                -2, -1
            };

            int counter = 0;
            
            while (true)
            {
                int maxCount = 0;
                int maxRow = 0;
                int maxCol = 0;

                for (int row = 0; row < chess.GetLength(0); row++)
                {
                    for (int col = 0; col < chess.GetLength(1); col++)
                    {
                        int currentCount = 0;

                        if (chess[row, col] == 'K')
                        {

                            for (int i = 0; i < indexes.Length; i += 2)
                            {
                                if (IsValid(chess, row + indexes[i], col + indexes[i + 1]) 
                                    && chess[row + indexes[i], col + indexes[i + 1]] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                chess[maxRow, maxCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
            
        }
        static bool IsValid(char[,] matrix, int neededRow, int needeCol)
        {
            return neededRow >= 0 && neededRow < matrix.GetLength(0)
                && needeCol >= 0 && needeCol < matrix.GetLength(1);

        }
    }
}
