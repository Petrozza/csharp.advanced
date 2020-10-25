using System;
using System.Data;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = sizes[0];
            int M = sizes[1];

            int[,] matrix = new int[N, M];

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] positions = input.Split().Select(int.Parse).ToArray();
                int rowPos = positions[0];
                int colPos = positions[1];

                if (rowPos < 0 || rowPos > N - 1 || colPos < 0 || colPos > M - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int row = 0; row < N; row++)
                {
                    matrix[row, colPos] += 1;

                }

                for (int col = 0; col < M; col++)
                {
                    matrix[rowPos, col] += 1;
                }

                matrix[rowPos, colPos] = 1;
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }




    }
}
