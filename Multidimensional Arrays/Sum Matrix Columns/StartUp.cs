using System;
using System.Dynamic;
using System.Linq;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimens = parseArea(new[] { ' ', ',' });

            int rows = dimens[0];
            int cols = dimens[1];


            int[,] patrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = parseArea(new[] { ' ' });

                for (int col = 0; col < cols; col++)
                {
                    patrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < patrix.GetLength(1); col++)
            {
                int currentSum = 0;

                for (int row = 0; row < patrix.GetLength(0); row++)
                {
                    currentSum += patrix[row, col];
                }

                Console.WriteLine(currentSum);
            }
        }

        private static int[] parseArea(char[] splitSymbols)
        {
            return Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

