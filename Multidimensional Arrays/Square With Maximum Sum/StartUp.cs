using System;
using System.Dynamic;
using System.Linq;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimens = parseArea(new[] { ", " });

            int rows = dimens[0];
            int cols = dimens[1];


            int[,] patrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = parseArea(new[] { ", " });

                for (int col = 0; col < cols; col++)
                {
                    patrix[row, col] = currentRow[col];
                }
            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < patrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < patrix.GetLength(1) - 1; col++)
                {
                    int currentSum = patrix[row, col]
                        + patrix[row, col + 1]
                        + patrix[row + 1, col]
                        + patrix[row + 1, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"{ patrix[maxRow, maxCol]} {patrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{ patrix[maxRow + 1, maxCol]} {patrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] parseArea(string[] splitSymbols)
        {
            return Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
