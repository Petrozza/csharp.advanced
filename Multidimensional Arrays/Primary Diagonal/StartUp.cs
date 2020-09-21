using System;
using System.Linq;

namespace Primary_Diagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sumDiag = 0;

            for (int i = 0; i < size; i++)
            {
                sumDiag += matrix[i, i];
            }

            Console.WriteLine(sumDiag);
        }
    }
}
