using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];


            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int vert = 0; vert < size; vert++)
            {
                for (int hor = 0; hor < size; hor++)
                {
                    if (hor == vert)
                    {
                        sum1 += matrix[vert, hor];
                    }
                }
            }

            for (int vert = 0; vert < size; vert++)
            {
                for (int hor = 0; hor < size; hor++)
                {
                    if (vert + hor == size -1)
                    {
                    sum2 += matrix[vert, hor];

                    }
                }
            }

            Console.WriteLine($"{Math.Abs(sum1-sum2)}");


        }
    }
}
