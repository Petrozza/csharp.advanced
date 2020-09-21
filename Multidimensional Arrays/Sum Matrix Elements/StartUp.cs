using System;
using System.Dynamic;
using System.Linq;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimens = parseArea();

            int rows = dimens[0];
            int cols = dimens[1];

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int[,] patrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = parseArea();

                for (int col = 0; col < cols; col++)
                {
                    patrix[row, col] = currentRow[col];
                }
            }
            int sum = 0;
            foreach (var item in patrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }

        private static int[] parseArea()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

