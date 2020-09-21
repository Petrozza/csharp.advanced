using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            fillMatrix(matrix);

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }


                if (input[0] != "swap" || input.Length != 5)

                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                if (row1 < 0 || row1 >= dimensions[0]
                    || row2 < 0 || row2 >= dimensions[0]
                    || col1 < 0 || col1 >= dimensions[1]
                    || col2 < 0 || col2 >= dimensions[1])
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string tempElement = string.Empty;

                tempElement = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = tempElement;
                printMatrix(matrix);
            }
        }
        private static void printMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void fillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
