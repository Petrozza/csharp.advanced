using System;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] path = new char[dimensions[0], dimensions[1]];
            string snake = Console.ReadLine();

            int counter = 0;
            for (int row = 0; row < path.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < path.GetLength(1); col++)
                    {
                        counter = ProcessCounter(path, snake, counter, row, col);
                    }
                }
                else
                {
                    for (int col = path.GetLength(1) - 1; col >= 0; col--)
                    {
                        counter = ProcessCounter(path, snake, counter, row, col);
                    }
                }

            }
            printMatrix(path);


        }

        private static int ProcessCounter(char[,] path, string snake, int counter, int row, int col)
        {
            path[row, col] = snake[counter++];

            if (counter == snake.Length)
            {
                counter = 0;
            }

            return counter;
        }

        private static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
